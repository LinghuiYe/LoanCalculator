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
        public int LoanType { get; set; }
        public Enums.PaybackSchemeEnum PaybackSchemeType { get; set; }
        public double Interest { get; set; } //annual Interest
        public int PaybackYears { get; set; }
        public double LoanAmount { get; set; }
        public double PaybackTotalAmount { get; set; }
        public double TotalInterests { get; set; }
        public IList<PaybackPlan> PayDetails { get; set; }

        public virtual void calculatorPayment()
        {
            switch (PaybackSchemeType)
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
            var rate = Global.loadTypes.Where(item => item.id == LoanType).ToList()[0].value;
            this.PayDetails = HelpMethods.EMICalculator(rate, PaybackYears, LoanAmount);
        }

        public void EqualPrincipalMethod()
        {
            throw new NotImplementedException();
        }
    }
}
