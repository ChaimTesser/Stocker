using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            var runData = new RunData();
            // Start Date, End Date, High, Max, Drop, Load Only Pct Changes
            runData.Run(new DateTime(2019,01, 01), new DateTime(2020, 05, 01), 0.05, 10, -0.3,true);
            //LoadData.LoadAllData();
        }
    }

}
