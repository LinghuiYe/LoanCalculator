using LoanCalculator.Interfaces;
using LoanCalculator.Models;
using LoanCalculator.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Loans
{
    public class Loan: IPaybackScheme
    {
        public int loanType { get; set; }
        public Enums.PaybackSchemeEnum paybackSchemeType { get; set; }
        public int paybackYears { get; set; }
        public double loanAmount { get; set; }
        public IList<PaybackPlan> payDetails { get; set; }

        public virtual void CalculatorPayment()
        {
            switch (paybackSchemeType)
            {
                case Enums.PaybackSchemeEnum.EMI:
                    EqualPrincipalandInterestMethod();
                    break;
                case Enums.PaybackSchemeEnum.EM:
                    EqualPrincipalMethod();
                    break;
            }
        }

        public void EqualPrincipalandInterestMethod()
        {
            var loadTypesList = Global.loadTypes.Where(item => item.id == loanType).ToList();
            if (loadTypesList.Count > 0) 
            {
                this.payDetails = HelperMethods.EMICalculator(loadTypesList[0].value, paybackYears, loanAmount);
            }
        }

        public void EqualPrincipalMethod()
        {
            throw new NotImplementedException();
        }
    }
}
