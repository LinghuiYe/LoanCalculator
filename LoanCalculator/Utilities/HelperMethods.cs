using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Utilities
{
    public static class HelperMethods
    {
        public static IList<PaybackPlan> EMICalculator(double Interest, int PaybackYears, double LoanAmount)
        {
            IList<PaybackPlan> PayDetails = new List<PaybackPlan>();

            // monthly Insteres
            double mIns = Interest / 100 / 12;

            // Months Num
            int months = PaybackYears * 12;

            double pow = Math.Pow(1 + mIns, months);

            double remains = LoanAmount;

            double PaybackTotalAmount = (months * LoanAmount * mIns * pow) / (pow - 1);
            PaybackTotalAmount = Math.Floor(PaybackTotalAmount * 100 + 0.5) / 100;

            double TotalInterests = PaybackTotalAmount - LoanAmount;
            TotalInterests = Math.Floor(TotalInterests * 100 + 0.5) / 100;

            for (int i = 0; i < months; i++)
            {
                PaybackPlan pp = new PaybackPlan();
                pp.PaybackDate = DateTime.Now.AddMonths(i + 1).Date.ToString("yyyy-MM-dd");
                if (i == months - 1)
                {
                    pp.MonthlyPayAmount = Math.Floor(remains * 100 + 0.5) / 100;
                    pp.MonthlyPayInterest = Math.Floor(remains * mIns * 100 + 0.5) / 100;
                    pp.MonthlyPayTotal = Math.Floor((remains + remains * mIns) * 100 + 0.5) / 100;
                    pp.OutstandingDebt = 0;
                }
                else 
                {
                    pp.MonthlyPayInterest = Math.Floor(remains * mIns * 100 + 0.5) / 100;
                    pp.MonthlyPayTotal = Math.Floor(PaybackTotalAmount / months * 100 + 0.5) / 100;
                    pp.MonthlyPayAmount = Math.Floor((PaybackTotalAmount / months - remains * mIns) * 100 + 0.5) / 100;
                    pp.OutstandingDebt = Math.Floor((remains + remains * mIns - (PaybackTotalAmount / months)) * 100 + 0.5) / 100;
                }
                remains -= pp.MonthlyPayAmount;
                PayDetails.Add(pp);
            }

            return PayDetails;
        }
    
        
    }
}
