using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class PaybackPlan
    {
        public string paybackDate { get; set; } 
        public double monthlyPayAmount { get; set; }    // Instalments
        public double monthlyPayInterest { get; set; }  // Interest and changes
        public double monthlyPayTotal { get; set; }     //  To pay
        public double outstandingDebt { get; set; }
    }
}
