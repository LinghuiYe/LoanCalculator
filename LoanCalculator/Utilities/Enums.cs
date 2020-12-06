using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Utilities
{
    public class Enums
    {
        public enum LoanTypeEnum
        {
            HousingLoan = 1,
            CarLoan = 2,
            SpendingLoan = 3
        };

        public enum PaybackSchemeEnum
        {
            EMI,    // Equal principal and interest
            EM      // Equal Principal
        };
    }
}
