using System;

namespace LoanCalculator
{
    public class Loan
    {
        public double Amount { get; set; }

        public double Interest { get; set; }

        public string InterestType { get; set; }

        public int PaybackTime { get; set; }
    }
}
