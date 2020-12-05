using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Utilities
{
    public static class HelperMethods
    {
        public static IList<PaybackPlan> EMICalculator(double interest, int paybackYears, double loanAmount)
        {
            IList<PaybackPlan> payDetails = new List<PaybackPlan>();

            // monthly Insterest
            double monthlyInsterest = interest / 100 / 12;

            // Months count
            int months = paybackYears * 12;

            double pow = Math.Pow(1 + monthlyInsterest, months);

            // Remain amount
            double remains = loanAmount;

            double PaybackTotalAmount = (months * loanAmount * monthlyInsterest * pow) / (pow - 1);
            PaybackTotalAmount = Math.Floor(PaybackTotalAmount * 100 + 0.5) / 100;

            for (int i = 0; i < months; i++)
            {
                PaybackPlan paybackPlan = new PaybackPlan();
                paybackPlan.paybackDate = DateTime.Now.AddMonths(i + 1).Date.ToString("yyyy-MM-dd");
                
                // Calculate the last month's payment seperately because of deviation.
                if (i == months - 1)
                {
                    // keep two decimal places
                    paybackPlan.monthlyPayAmount = Math.Floor(remains * 100 + 0.5) / 100;
                    paybackPlan.monthlyPayInterest = Math.Floor(remains * monthlyInsterest * 100 + 0.5) / 100;
                    paybackPlan.monthlyPayTotal = Math.Floor((remains + remains * monthlyInsterest) * 100 + 0.5) / 100;
                    paybackPlan.outstandingDebt = 0;
                }
                else 
                {
                    paybackPlan.monthlyPayInterest = Math.Floor(remains * monthlyInsterest * 100 + 0.5) / 100;
                    paybackPlan.monthlyPayTotal = Math.Floor(PaybackTotalAmount / months * 100 + 0.5) / 100;
                    paybackPlan.monthlyPayAmount = Math.Floor((PaybackTotalAmount / months - remains * monthlyInsterest) * 100 + 0.5) / 100;
                    paybackPlan.outstandingDebt = Math.Floor((remains + remains * monthlyInsterest - (PaybackTotalAmount / months)) * 100 + 0.5) / 100;
                }

                remains -= paybackPlan.monthlyPayAmount;
                payDetails.Add(paybackPlan);
            }

            return payDetails;
        }
    
        
    }
}
