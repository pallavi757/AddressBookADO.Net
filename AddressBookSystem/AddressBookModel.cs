using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookModel
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Zip { get; set; }
        public double PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
