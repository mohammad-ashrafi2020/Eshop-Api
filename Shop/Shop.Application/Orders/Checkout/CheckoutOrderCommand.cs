using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommand : IBaseCommand
    {
        public CheckoutOrderCommand(long userId, string shire, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public long UserId { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}