using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker
{
    public class DateStructure
    {
        public DateTimeOffset Date { get; set; }
        public List<StockAndPrice> StockAndPrices {get;set;}
        public DateTimeOffset SellDate { get; set; }
        public DateTimeOffset BoughtDate { get; set; }
        public bool Bought = false;

    }
    public class StockAndPrice
    {
        public string Stock { get; set; }
        public double Price { get; set; }
    }

    public class Balance
    {
        public DateTime Date { get; set; }
        public double Inv { get; set; }
        public double Int { get; set; }
    }

}
