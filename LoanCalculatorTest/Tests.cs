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
                    paybackDate=DateTime.Now.AddMonths(1).Date.ToString("yyyy-MM-dd"),
                    monthlyPayAmount = 458.25,
                    monthlyPayInterest = 87.5,
                    monthlyPayTotal = 545.75,
                    outstandingDebt = 29541.75
                },
                new PaybackPlan()
                {
                    paybackDate=DateTime.Now.AddMonths(10).Date.ToString("yyyy-MM-dd"),
                    monthlyPayAmount = 470.42,
                    monthlyPayInterest = 75.33,
                    monthlyPayTotal = 545.75,
                    outstandingDebt = 25356.88
                },
                new PaybackPlan()
                {
                    paybackDate=DateTime.Now.AddMonths(years*12).Date.ToString("yyyy-MM-dd"),
                    monthlyPayAmount = 544.21,
                    monthlyPayInterest = 1.59,
                    monthlyPayTotal = 545.8,
                    outstandingDebt = 0
                }
            };

            IList<PaybackPlan> res = HelperMethods.EMICalculator(interest, years, loanAmount);
            Assert.AreEqual(res[0].paybackDate, Payplan_expected[0].paybackDate);
            Assert.AreEqual(res[0].monthlyPayAmount, Payplan_expected[0].monthlyPayAmount);
            Assert.AreEqual(res[0].monthlyPayInterest, Payplan_expected[0].monthlyPayInterest);
            Assert.AreEqual(res[0].monthlyPayTotal, Payplan_expected[0].monthlyPayTotal);
            Assert.AreEqual(res[0].outstandingDebt, Payplan_expected[0].outstandingDebt);

            Assert.AreEqual(res[9].paybackDate, Payplan_expected[1].paybackDate);
            Assert.AreEqual(res[9].monthlyPayAmount, Payplan_expected[1].monthlyPayAmount);
            Assert.AreEqual(res[9].monthlyPayInterest, Payplan_expected[1].monthlyPayInterest);
            Assert.AreEqual(res[9].monthlyPayTotal, Payplan_expected[1].monthlyPayTotal);
            Assert.AreEqual(res[9].outstandingDebt, Payplan_expected[1].outstandingDebt);

            Assert.AreEqual(res[years * 12 - 1].paybackDate, Payplan_expected[2].paybackDate);
            Assert.AreEqual(res[years * 12 - 1].monthlyPayAmount, Payplan_expected[2].monthlyPayAmount);
            Assert.AreEqual(res[years * 12 - 1].monthlyPayInterest, Payplan_expected[2].monthlyPayInterest);
            Assert.AreEqual(res[years * 12 - 1].monthlyPayTotal, Payplan_expected[2].monthlyPayTotal);
            Assert.AreEqual(res[years * 12 - 1].outstandingDebt, Payplan_expected[2].outstandingDebt);

        }
    }
}