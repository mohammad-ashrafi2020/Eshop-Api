using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }

        public string ShippingType { get; private set; }
        public int ShippingCost { get; private set; }
    }
}