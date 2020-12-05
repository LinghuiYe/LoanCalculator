using LoanCalculator.Loans;
using LoanCalculator.Models;
using LoanCalculator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Controllers
{
    [ApiController]
    public class PayPlanController : ControllerBase
    {
        private readonly ILogger<PayPlanController> _logger;

        public PayPlanController(ILogger<PayPlanController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IEnumerable<PaybackPlan> Post([FromBody] Loan loan)
        {
            loan.calculatorPayment();
            return loan.PayDetails as IEnumerable<PaybackPlan>;

        }
    }
}
