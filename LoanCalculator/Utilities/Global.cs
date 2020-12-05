using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Utilities
{
    public static class Global
    {
        public static IList<LoanType> loadTypes = new List<LoanType>()
        {
            new LoanType() { id=1, name="Boliglån", value=3.5},
            new LoanType() { id=2, name="Billån", value=10.5},
            new LoanType() { id=3, name="Forbrukslån", value=4.8}
        };
    }
}
