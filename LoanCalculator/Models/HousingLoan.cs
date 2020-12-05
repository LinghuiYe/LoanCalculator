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
            base.loanType = (int)Enums.LoanTypeEnum.HousingLoan;
            base.paybackSchemeType = Enums.PaybackSchemeEnum.EMI;
        }
    }
}
