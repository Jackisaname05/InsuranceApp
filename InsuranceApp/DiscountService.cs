using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp
{
    public class DiscountService : IDiscountService
    {
        public double GetDiscount()
        {
            return 0.9; // 10% discount for over 50s
        }
    }
}
