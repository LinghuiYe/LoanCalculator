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

            IList<PaybackPlan> payPlanExpected = new List<PaybackPlan>()
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

            IList<PaybackPlan> payPlanRes = HelperMethods.EMICalculator(interest, years, loanAmount);

            Assert.AreEqual(payPlanRes[0].paybackDate, payPlanExpected[0].paybackDate);
            Assert.AreEqual(payPlanRes[0].monthlyPayAmount, payPlanExpected[0].monthlyPayAmount);
            Assert.AreEqual(payPlanRes[0].monthlyPayInterest, payPlanExpected[0].monthlyPayInterest);
            Assert.AreEqual(payPlanRes[0].monthlyPayTotal, payPlanExpected[0].monthlyPayTotal);
            Assert.AreEqual(payPlanRes[0].outstandingDebt, payPlanExpected[0].outstandingDebt);

            Assert.AreEqual(payPlanRes[9].paybackDate, payPlanExpected[1].paybackDate);
            Assert.AreEqual(payPlanRes[9].monthlyPayAmount, payPlanExpected[1].monthlyPayAmount);
            Assert.AreEqual(payPlanRes[9].monthlyPayInterest, payPlanExpected[1].monthlyPayInterest);
            Assert.AreEqual(payPlanRes[9].monthlyPayTotal, payPlanExpected[1].monthlyPayTotal);
            Assert.AreEqual(payPlanRes[9].outstandingDebt, payPlanExpected[1].outstandingDebt);

            Assert.AreEqual(payPlanRes[years * 12 - 1].paybackDate, payPlanExpected[2].paybackDate);
            Assert.AreEqual(payPlanRes[years * 12 - 1].monthlyPayAmount, payPlanExpected[2].monthlyPayAmount);
            Assert.AreEqual(payPlanRes[years * 12 - 1].monthlyPayInterest, payPlanExpected[2].monthlyPayInterest);
            Assert.AreEqual(payPlanRes[years * 12 - 1].monthlyPayTotal, payPlanExpected[2].monthlyPayTotal);
            Assert.AreEqual(payPlanRes[years * 12 - 1].outstandingDebt, payPlanExpected[2].outstandingDebt);

        }
    }
}