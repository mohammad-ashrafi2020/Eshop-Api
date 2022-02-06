using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IDomainUserService
    {
        bool IsEmailExist(string email);

        bool PhoneNumberIsExist(string phoneNumber);
    }
}