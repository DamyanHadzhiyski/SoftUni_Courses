﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06.FoodShortage
{
    public interface IBuyer
    {
        int Food { get; set; }

        void BuyFood();
    }
}
