using System;
namespace AddressBookSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem Ado.Net");
            Details details = new Details();
            int option = 0;
            do
            {
                Console.WriteLine("1: For check Connection");
                Console.WriteLine("2: Get All Records from AddressBook Contact Details");
                Console.WriteLine("3: For Update The Contact");
                //Console.WriteLine("4: For Get Contact In Given Date");
                Console.WriteLine("5: For Get Contact From city and state ");
                Console.WriteLine("0: For Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:

                        details.EstablishConnection();
                        Console.WriteLine("Connection estsablished");
                        break;
                    case 2:
                        Details.GetAddressBookDetails();
                        //details.GetAddressBookDetails();

                        break;
                    case 3:
                        AddressBookModel addressbook = new AddressBookModel();
                        Console.WriteLine("Enter a First Name for Update Contact");
                        string firstname = Console.ReadLine();
                        addressbook.First_Name = firstname;
                        Console.WriteLine("Enter Last Name");
                        string lastname = Console.ReadLine();
                        addressbook.Last_Name = lastname;
                        Console.WriteLine("Enter Address");
                        string address = Console.ReadLine();
                        addressbook.Address = address;
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        addressbook.City = city;
                        Console.WriteLine("Enter State");
                        string State = Console.ReadLine();
                        addressbook.State = State;
                        Console.WriteLine("Enter Zip");
                        double zip = Convert.ToInt64(Console.ReadLine());
                        addressbook.Zip = zip;
                        Console.WriteLine("Enter PhoneNumber");
                        double Phone = Convert.ToInt64(Console.ReadLine());
                        addressbook.PhoneNumber = Phone;
                        Console.WriteLine("Enter Email");
                        string Email = Console.ReadLine();
                        addressbook.Email = Email;
                        Console.WriteLine("Enter a Address Book Name");
                        string Name = Console.ReadLine();
                        addressbook.Name = Name;
                        Console.WriteLine("Enter type");
                        string type = Console.ReadLine();
                        addressbook.Type = type;
                        Details.UpdateContact(addressbook);
                        Console.WriteLine("Contact is Updated");
                        break;
                    //case 4:
                    //    // AddressBookModel getDate = new AddressBookModel();

                    //    Details.GetContactInGivenDateRange();
                    //    break;
                    case 5:
                        AddressBookModel getData = new AddressBookModel();
                        Console.Write("Enter the City Name:");
                        string cityname = Console.ReadLine();
                        getData.City = cityname;
                        Console.Write("Enter the State Name:");
                        string statename = Console.ReadLine();
                        getData.State = statename;
                        details.GetDataFromCityAndState(getData);
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            while (option != 0);

        }
    }
}
