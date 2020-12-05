using LoanCalculator.Models;
using LoanCalculator.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LoanCalculatorTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void EMICalculator_TestMethod()
        {
            double interest = 3.5;
            int years = 5;
            double loanAmount = 30000;

            IList<PaybackPlan> Payplan_expected = new List<PaybackPlan>()
            {
                new PaybackPlan()
                {
                    PaybackDate=DateTime.Now.AddMonths(1).Date.ToString("yyyy-MM-dd"),
                    MonthlyPayAmount = 458.25,
                    MonthlyPayInterest = 87.5,
                    MonthlyPayTotal = 545.75,
                    OutstandingDebt = 29541.75
                },
                new PaybackPlan()
                {
                    PaybackDate=DateTime.Now.AddMonths(10).Date.ToString("yyyy-MM-dd"),
                    MonthlyPayAmount = 470.42,
                    MonthlyPayInterest = 75.33,
                    MonthlyPayTotal = 545.75,
                    OutstandingDebt = 25356.88
                },
                new PaybackPlan()
                {
                    PaybackDate=DateTime.Now.AddMonths(years*12).Date.ToString("yyyy-MM-dd"),
                    MonthlyPayAmount = 544.21,
                    MonthlyPayInterest = 1.59,
                    MonthlyPayTotal = 545.8,
                    OutstandingDebt = 0
                }
            };

            IList<PaybackPlan> res = HelperMethods.EMICalculator(interest, years, loanAmount);
            Assert.AreEqual(res[0].PaybackDate, Payplan_expected[0].PaybackDate);
            Assert.AreEqual(res[0].MonthlyPayAmount, Payplan_expected[0].MonthlyPayAmount);
            Assert.AreEqual(res[0].MonthlyPayInterest, Payplan_expected[0].MonthlyPayInterest);
            Assert.AreEqual(res[0].MonthlyPayTotal, Payplan_expected[0].MonthlyPayTotal);
            Assert.AreEqual(res[0].OutstandingDebt, Payplan_expected[0].OutstandingDebt);

            Assert.AreEqual(res[9].PaybackDate, Payplan_expected[1].PaybackDate);
            Assert.AreEqual(res[9].MonthlyPayAmount, Payplan_expected[1].MonthlyPayAmount);
            Assert.AreEqual(res[9].MonthlyPayInterest, Payplan_expected[1].MonthlyPayInterest);
            Assert.AreEqual(res[9].MonthlyPayTotal, Payplan_expected[1].MonthlyPayTotal);
            Assert.AreEqual(res[9].OutstandingDebt, Payplan_expected[1].OutstandingDebt);

            Assert.AreEqual(res[years * 12 - 1].PaybackDate, Payplan_expected[2].PaybackDate);
            Assert.AreEqual(res[years * 12 - 1].MonthlyPayAmount, Payplan_expected[2].MonthlyPayAmount);
            Assert.AreEqual(res[years * 12 - 1].MonthlyPayInterest, Payplan_expected[2].MonthlyPayInterest);
            Assert.AreEqual(res[years * 12 - 1].MonthlyPayTotal, Payplan_expected[2].MonthlyPayTotal);
            Assert.AreEqual(res[years * 12 - 1].OutstandingDebt, Payplan_expected[2].OutstandingDebt);

        }
    }
}