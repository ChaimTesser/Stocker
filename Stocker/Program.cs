using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stocker
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var runData = new RunDataV2();
                // Start Date, End Date, High, Max, Drop, Load Only Pct Changes
             runData.Run(new DateTime(2010, 01, 01), new DateTime(2018, 12, 31), 999, 10, -0.5, -0.3);
            //   LoadData.LoadAllData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }

}
