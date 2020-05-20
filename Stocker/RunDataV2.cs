using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stocker
{
    public class RunDataV2
    {
        double startBal = 1000.0;
        double profit = 0.0;
        bool _pctOnly;

        List<DateStructure> Buys = new List<DateStructure>();
        List<DateStructure> Sells = new List<DateStructure>();
        List<DateStructure> Owned = new List<DateStructure>();
        List<Balance> Balances = new List<Balance>();
        List<StockHist> AllStockHistory = new List<StockHist>();

        List<string> log = new List<string>();
        double tempBal = 0.0;
        double _change = 0.0;
        double _high;
        double _drop;
        double _minDrop;
        public void Run(DateTime startDate, DateTime endDate, double change, double high, double drop, double minDrop, bool pctOnly = false)
        {
            _pctOnly = pctOnly;
            _high = high;
            _drop = drop;
            _change = change;
            _minDrop = minDrop;

            // set years to sample
            var years = new List<string> { startDate.Year.ToString() };
            if (startDate.Year != endDate.Year)
            {
                var end = endDate.Year;
                while (end != startDate.Year)
                {
                    years.Add(end.ToString());
                    end--;
                }
            }
            var count = 0;
            var added = new List<string>();
            foreach (var year in years)
            {
                using (var reader = new StreamReader($@"C:\temp\{year}.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        StockHist st = new StockHist();
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        st.Date = DateTime.Parse(values[0]);
                        st.Symbol = values[1];
                        st.Open = Double.Parse(values[2]);
                        st.High = Double.Parse(values[3]);
                        st.Low = Double.Parse(values[4]);
                        st.Close = Double.Parse(values[5]);
                        if (st.Date.Date >= startDate && st.Date.Date <= endDate)
                            AllStockHistory.Add(st);
                    }
                }
            }

            var stocksInRange = AllStockHistory.Select(d => d.Date).Distinct().OrderBy(d => d.Date);
            var c = stocksInRange.Count();
            foreach (var date in stocksInRange)
            {
                //if (!added.Contains(s.Symbol))
                Lookup(date.Date, count++, c);
                //added.Add(s.Symbol);
            }

            if (_pctOnly)
                File.WriteAllLines(Path.Combine("c:\\temp", "pct" + _drop + ".csv"), log);
            else
            {
                Buy(startBal, Buys.OrderBy(b => b.Date).First().Date);
                foreach (var s in Sells.OrderBy(s => s.SellDate))
                {
                    Buy(Sell(s), s.SellDate);
                }

                var rep = new List<string>();
                foreach (var b in Balances)
                {
                    rep.Add(
                        $"{b.Date}," +
                        $"{b.Inv}," +
                        $"{b.Int}," +
                        $"{b.Inv + b.Int}"
                        );
                }
                File.WriteAllLines(Path.Combine("c:\\temp", startDate.ToString("ddMMyyyy") + "-" + endDate.ToString("ddMMyyyy") + "-1000-shigh-" + _high + "-Change" + _change + "drop-" + _drop + "V2-02.csv"), rep);
            }
        }

        public void Lookup(DateTime date, int cnt, int t)
        {
            var drop = _drop;

            var StockHistory = AllStockHistory.Where(x => x.Date == date).Where(x => x.Open <= _high).ToArray();
            if (StockHistory.Count() > 0)
            {
                var lookForNext = new List<double> { drop };
                while (lookForNext.Count() > 0)
                {
                    var dr = lookForNext.OrderBy(x=>x).First();
                    var chnge = -dr - 0.1;
                    lookForNext.Clear();
                    foreach (var sh in StockHistory)
                    {
                        Console.Write("\r Loading " + cnt + "/" + t);
                        lookForNext.AddRange( GetData(sh,dr,chnge));
                    }
                }
            }
        }

        public List<double> GetData(StockHist sh, double drp, double chnge)
        {
            var otherDrops = new List<double>();
            if (Buys.SingleOrDefault(b => b.Date == sh.Date) == null || !Buys.SingleOrDefault(b => b.Date == sh.Date).StockAndPrices.Select(b => b.Stock).Contains(sh.Symbol))
            {
                
                // var AllStockHistories = AllStockHistory.Where(st => st.Symbol == sh.Symbol).OrderBy(x => x.Date).ToArray();
                var pchange = (sh.Close - sh.Open) / sh.Open;
                if (pchange <= drp)
                {
                    var next = AllStockHistory.Where(s => s.Symbol == sh.Symbol).Where(s => s.Date > sh.Date).OrderBy(s => s.Date).FirstOrDefault();// Index = Array.IndexOf(AllStockHistories, sh) + 1;
                    if (next != null)
                    {
                        //  var next = AllStockHistories[nextIndex];
                        // var next2 = All[nextIndex + 1];
                        var dt = new DateTime();

                        var cng = (next.High - sh.Close) / next.Close;

                        if (_pctOnly)
                        {
                            log.Add(
                                $"{sh.Date.Date}," +
                                $"{cng}"
                                );
                        }
                        else
                        {
                            var sell = 0.0;

                            if (cng >= chnge)
                            {
                                dt = next.Date.DateTime;
                                sell = sh.Close + ((sh.Close / 100) * (chnge * 100));
                            }
                            //else if (((next2.High - sh.Close) / next2.Close) >= _change)
                            //{
                            //    dt = next2.Date.DateTime;
                            //    sell = sh.Close + ((sh.Close / 100) * (_change * 100));
                            //}
                            else
                            {
                                dt = next.Date.DateTime;
                                sell = next.Close;
                            }
                            if (Buys.SingleOrDefault(b => b.Date == sh.Date) == null)
                                Buys.Add(new DateStructure() { Date = sh.Date, SellDate = dt, StockAndPrices = new List<StockAndPrice>() { new StockAndPrice() { Stock = sh.Symbol, Price = sh.Close } } });
                            else
                                Buys.SingleOrDefault(b => b.Date == sh.Date).StockAndPrices.Add(new StockAndPrice() { Stock = sh.Symbol, Price = sh.Close });
                            if (Sells.SingleOrDefault(b => b.BoughtDate == sh.Date) == null)
                                Sells.Add(new DateStructure() { SellDate = dt, BoughtDate = sh.Date, StockAndPrices = new List<StockAndPrice>() { new StockAndPrice() { Stock = sh.Symbol, Price = sell } } });
                            else
                                Sells.SingleOrDefault(b => b.BoughtDate == sh.Date).StockAndPrices.Add(new StockAndPrice() { Stock = sh.Symbol, Price = sell });
                        }
                    }
                }
                else
                {
                    while (drp <= _minDrop)
                    {
                        drp += 0.1;
                        if (pchange <= drp)
                            otherDrops.Add(drp);
                    }
                }
            }
            return otherDrops;
        }


        public void Buy(double bal, DateTimeOffset date)
        {
            var availDates = Buys.Where(b => b.Date >= date);
            if (availDates.Count() > 0 && bal != 0)
            {
                //Price for bought = Quantity
                var buys = availDates.OrderBy(b => b.Date).First();
                var buyDate = buys.Date;
                var bought = new DateStructure { Date = buyDate, StockAndPrices = new List<StockAndPrice>() };
                var stop = false;
                while (!stop)
                {
                    foreach (var s in buys.StockAndPrices)
                    {
                        if (bal >= s.Price)
                        {
                            if (bought.StockAndPrices.SingleOrDefault(x => x.Stock == s.Stock) == null)
                                bought.StockAndPrices.Add(new StockAndPrice { Stock = s.Stock, Price = 1 });
                            else
                                bought.StockAndPrices.SingleOrDefault(x => x.Stock == s.Stock).Price++;
                            bal -= s.Price;
                        }
                        else
                        {
                            stop = true;
                            tempBal = bal;
                        }
                    }
                }
                Owned.Add(bought);
            }
        }
        public double Sell(DateStructure sell)
        {
            double bal = tempBal;
            if (Owned.Where(o => o.Date == sell.BoughtDate).Count() > 0)
            {
                try
                {
                    foreach (var s in sell.StockAndPrices)
                    {
                        bal += Owned.Where(o => o.Date == sell.BoughtDate).SelectMany(z => z.StockAndPrices).Where(x => x.Stock == s.Stock).Select(p => p.Price).Sum() * sell.StockAndPrices.Single(x => x.Stock == s.Stock).Price;
                    }

                }
                catch
                {

                }
                var prof = 0.0;
                if (bal > startBal)
                    prof = bal - startBal;
                profit += prof;
                bal -= prof;
                if (Balances.SingleOrDefault(b => b.Date == sell.SellDate) == null)
                    Balances.Add(new Balance { Date = sell.SellDate.DateTime, Inv = bal, Int = profit });
                else
                {
                    Balances.SingleOrDefault(b => b.Date == sell.SellDate).Inv += bal;
                    Balances.SingleOrDefault(b => b.Date == sell.SellDate).Int = profit;
                }
            }
            return bal;
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
