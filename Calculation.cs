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
        public string modificationName { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal priceItem { get; set; }
        public int cycleTime { get; set; }


        //results
        public int daysCount { get; set; }
        public int machineWorkingTime { get { return daysCount * 8; } set { } }




        public Calculation(string modificationName, DateTime beginDate, DateTime endDate, decimal priceItem, int cycleTime )
        {
            this.modificationName = modificationName;
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.priceItem = priceItem;
            this.cycleTime = cycleTime;
        }


    }

  
}
