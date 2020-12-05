using LoanCalculator.Models;
using LoanCalculator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LoanCalculator.Utilities.Enums;

namespace LoanCalculator.Controllers
{
    [ApiController]
    public class LoanTypeController : ControllerBase
    {
        private readonly ILogger<LoanTypeController> _logger;

        public LoanTypeController(ILogger<LoanTypeController> logger)
        {
            _logger = logger;
        }

        // GET: api/loantype
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<LoanType> Get()
        {
            return Global.loadTypes as IEnumerable<LoanType>;
        }
    }
}
