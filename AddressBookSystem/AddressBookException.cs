using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookException:Exception
    {
        ExceptionType exceptionType;
        public enum ExceptionType
        {
            Connection_Failed
        }
        public AddressBookException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
