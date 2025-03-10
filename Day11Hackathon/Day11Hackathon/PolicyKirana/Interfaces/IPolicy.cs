using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyKirana.Interfaces
{
    internal interface IPolicy
    {
        public void ShowAvailablePolicies();
        public void RegisterNewPolicies();
    }
}
