﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    internal class Commercial : VehicleType
    {
        public Commercial(double amount, double premium) : base(amount, premium)
        {
        }
        public override double InsuranceCalc()
        {
            return BaseAmount * BasePremium;
        }
    }
}
