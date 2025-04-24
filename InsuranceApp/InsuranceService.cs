using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp
{
    public class InsuranceService
    {
        private readonly IDiscountService _discountService;

        public InsuranceService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public double CalcPremium(int age, string gameMode)
        {
            double premium = 0.0;

            if (gameMode == "casual")
            {
                if (age >= 18 && age <= 30)
                    premium = 5.0;
                else if (age >= 31)
                    premium = 3.5;
            }
            else if (gameMode == "hardcore")
            {
                if (age >= 18 && age <= 35)
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
            }

            if (age >= 50)
            {
                double discount = _discountService.GetDiscount();
                premium *= discount;
            }

            return premium;
        }
    }
}

