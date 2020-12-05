using LoanCalculator.Interfaces;
using LoanCalculator.Loans;
using LoanCalculator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class HousingLoan : Loan
    {
        public HousingLoan()
        {
            base.LoanType = (int)Enums.LoanTypeEnum.HousingLoan;
            base.PaybackSchemeType = Enums.PaybackSchemeEnum.EMI;
        }
    }
}
