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
                Console.WriteLine("0: For Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:

                        details.EstablishConnection();
                        Console.WriteLine("Connection estsablished");
                        break;
                    case 2:
                        details.GetAddressBookDetails();

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
