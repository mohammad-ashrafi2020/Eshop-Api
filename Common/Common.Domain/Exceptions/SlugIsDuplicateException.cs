using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class SlugIsDuplicateException : BaseDomainException
    {
        public SlugIsDuplicateException() : base("slug تکراری است")
        {
        }

        public SlugIsDuplicateException(string message) : base(message)
        {
        }
    }
}