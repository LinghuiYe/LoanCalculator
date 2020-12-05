using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class PaybackPlan
    {
        public string PaybackDate { get; set; } 
        public double MonthlyPayAmount { get; set; }    // Instalments
        public double MonthlyPayInterest { get; set; }  // Interest and changes
        public double MonthlyPayTotal { get; set; }     //  To pay
        public double OutstandingDebt { get; set; }
    }
}
