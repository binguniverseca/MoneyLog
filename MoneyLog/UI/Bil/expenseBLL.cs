using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLog.BLL
{
    class expenseBLL
    {
        //Getters and Setters income/expense
        public int id { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }        
        public DateTime added_date { get; set; }
       

    }
}
