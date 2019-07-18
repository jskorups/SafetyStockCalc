using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyStockCalc
{
    class Calculation
    {
        //inputs
        public string SAP { get; set; }
        public string modificationName { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal priceItem { get; set; }
        public int cycleTime { get; set; }


        public int week1 { get; set; }
        public int week2 { get; set; }
        public int week3 { get; set; }
        public int week4 { get; set; }
        public int week5 { get; set; }


        //results
        public int daysCount { get; set; }
        public int machineWorkingTime { get { return daysCount * 8 /*zmienic na 7 i pol */; } set { } }
        public int periodicalResults { get; set; }
        public int productionPrice { get; set; }


        public static readonly Dictionary<string, int> dividingVars = new Dictionary<string, int>()
        {
        { "Tydzien", 7},
        { "Dwa tygodnie", 14},
        { "Miesiac(20 dni rob.)", 31},
        };
        


        public Calculation(string SAP, string modificationName, DateTime beginDate, DateTime endDate, decimal priceItem, int cycleTime )
        {
            this.SAP = SAP;
            this.modificationName = modificationName;
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.priceItem = priceItem;
            this.cycleTime = cycleTime;
            this.week1 = week1;
            this.week2 = week2;
            this.week3 = week3;
            this.week4 = week4;
            this.week5 = week5;
        }


        public int getQtyPeriodical(int divider)
        {
            periodicalResults = week1 + week2 + week3 + week4 + week5 / divider;
            return periodicalResults;
        }

    }

  
}
