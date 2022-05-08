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
            Connection_Failed, Contact_Not_Updated,  No_Data_In_Given_Date_Range, Contact_Not_Add
        }
        public AddressBookException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
