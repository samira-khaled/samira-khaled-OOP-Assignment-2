using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CheckoutBasket
{
    public class GiftWrapFeeCalculator
    {
        private const decimal GiftWrapFee = 4.99m;
        public decimal CalculateGiftWrapFee( bool isGiftWrapRequested)
        {
            return isGiftWrapRequested ? GiftWrapFee : 0m;


        }
    }
}
