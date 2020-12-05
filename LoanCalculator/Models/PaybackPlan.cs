using System;

namespace LoanCalculator
{
    public class PaybackPlan
    {
        public DateTime PaybackDate { get; set; }
        public double Amount { get; set; }
        public double InterestFee { get; set; }
        public double Deduction { get; set; }
        public double RestDebt { get; set; }
    }
}
