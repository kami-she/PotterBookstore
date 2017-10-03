using System;
using System.Collections.Generic;

namespace PotterBookstore
{
    public class PotterDiscountHelper : IDiscountHelper
    {
        private readonly Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>
        {
            {0, 0},
            {1, 0},
            {2, 0.05m},
            {3, 0.10m},
            {4, 0.15m},
            {5, 0.25m},
            {6, 0.30m},
            {7, 0.35m},
        };

        public decimal GetDiscount(int uniqueProductCount)
        {
            if (!_discounts.ContainsKey(uniqueProductCount))
            { 
                throw new InvalidOperationException("No discount found for this number of different books");
            }

            return _discounts[uniqueProductCount];
        }
    }
}
