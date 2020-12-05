using LoanCalculator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Interfaces
{
    interface IPaybackScheme
    {
        void EqualPrincipalandInterestMethod();
        void EqualPrincipalMethod();
    }
}
