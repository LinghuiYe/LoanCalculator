using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator;
using Microsoft.AspNetCore.Mvc;


namespace LoansCalculator.Controllers
{
    
    public class LoansController : Controller
    {
        // GET: api/loan
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Loan> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new Loan
            {
                InterestType = "Boliglån",
                Interest = 3.5,
            }
            ).ToArray();
        }

        // POST api/loans
        [HttpPost]
        [Route("api/[controller]/calculate")]
        public double getMonthlyPay([FromBody] Loan loan)
        {
            double monthlyRate = (loan.Interest / 12) / 100;
            double loanAmount = loan.Amount;
            double numberOfYerar = loan.PaybackTime;
            double monthlyPay = loanAmount * monthlyRate * Math.Pow((1 + monthlyRate), numberOfYerar * 12) /
                Math.Pow((1 + monthlyRate), numberOfYerar * 12 - 1);

            return Math.Round(monthlyPay);
        }

        [HttpPost]
        [Route("api/[controller]/plan")]
        public IEnumerable<PaybackPlan> getPaybackPlan([FromBody] Loan loan)
        {
            return Enumerable.Range(1, loan.PaybackTime * 12).Select(index => new PaybackPlan
            {
                Amount = 2,
                Deduction = 12,
                InterestFee = 20,
                PaybackDate = new DateTime(),
                RestDebt = 100
            }
            ).ToArray();
        }
    }
}
