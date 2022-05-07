using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Details
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=address_book_service;Integrated Security=True;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        //check connection
        public void EstablishConnection()
        {
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "connection failed");

                }
            }
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "connection failed");
                }
            }
        }
        //UC16-Retrive all data
        public static List<AddressBookModel> GetAddressBookDetails()
        {
            List<AddressBookModel> list = new List<AddressBookModel>();
            AddressBookModel address = new AddressBookModel();
            SqlConnection Connection = new SqlConnection(connectionString);
            using (Connection)
            {
                SqlCommand cmd = new SqlCommand("dbo.spGetAllAddressBookData", Connection);
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        address.ID = reader.GetInt32(0);
                        address.First_Name = reader.GetString(1);
                        address.Last_Name = reader.GetString(2);
                        address.Address = reader.GetString(3);
                        address.City = reader.GetString(4);
                        address.State = reader.GetString(5);
                        address.Zip = reader.GetInt64(6);
                        address.PhoneNumber = reader.GetInt64(7);
                        address.Email = reader.GetString(8);
                        address.Type = reader.GetString(9);
                        address.Name = reader.GetString(10);
                        list.Add(address);
                        Console.WriteLine(address.ID + "," + address.First_Name + "," + address.Last_Name + "," + address.Address + "," + address.City + ","
                            + address.State + "," + address.Zip + "," + address.PhoneNumber + "," + address.Email + "," + address.Type + "," + address.Name);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }
                Connection.Close();

            }
            return list;
        }
        //UC 17-update contact    
        public static bool UpdateContact(AddressBookModel address)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.EditContact", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@First_Name", address.First_Name);
                command.Parameters.AddWithValue("@Last_Name", address.Last_Name);
                command.Parameters.AddWithValue("@Address", address.Address);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@State", address.State);
                command.Parameters.AddWithValue("@Zip", address.Zip);
                command.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                command.Parameters.AddWithValue("@Email", address.Email);
                command.Parameters.AddWithValue("@Name", address.Name);
                command.Parameters.AddWithValue("@Type", address.Type);
                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new AddressBookException(AddressBookException.ExceptionType.Contact_Not_Updated, "Contact not updated");
                return false;
            }
        }
        //UC18
        //public static bool GetContactInGivenDateRange(DateTime Date)
        //{
        //    try
        //    {
        //        AddressBookModel address = new AddressBookModel();
        //        using SqlConnection connection = new(connectionString);
        //        SqlCommand command = new($"select First_Name,Last_Name,Address,City,State,Zipcode,PhoneNumber,Email,Date " +
        //        $"where date '{Date.Month}/{Date.Day}/{Date.Year}'", connection);
        //        connection.Open();
        //        SqlDataReader dr = command.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Console.WriteLine($"All Contacts from DB in given date {Date.ToShortDateString()}");
        //            // CustomPrint.PrintDashLine();
        //            Console.WriteLine(address.ID + "," + address.First_Name + "," + address.Last_Name + "," + address.Address + "," + address.City + ","
        //                     + address.State + "," + address.Zip + "," + address.PhoneNumber + "," + address.Email + "," + address.Type + "," + address.Name);
        //            //CustomPrint.PrintDashLine();
        //            while (dr.Read())
        //            {
        //               // addressBookObj.AddressBookName = dr.GetString(0);
        //                address.First_Name = dr.GetString(0);
        //                address.Last_Name = dr.GetString(1);
        //                address.Address = dr.GetString(2);
        //                address.City = dr.GetString(3);
        //                address.State = dr.GetString(4);
        //                address.Zip = dr.GetInt64(5);
        //                address.PhoneNumber = dr.GetInt64(6);
        //                address.Email = dr.GetString(7);
        //                address.Name = dr.GetString(8);
        //                address.Type = dr.GetString(9);
        //                address.Date = dr.GetDateTime(10);
        //                Console.WriteLine(address);
        //            }
        //           // CustomPrint.PrintDashLine();
        //            connection.Close();
        //            return true;
        //        }
        //        throw new AddressBookException(AddressBookException.ExceptionType. No_Data_In_Given_Date_Range, "No Contacts in Given Date Range");
        //    }
        //    catch (AddressBookException )
        //    {
        //       // CustomPrint.PrintInMagenta(e.Message);
        //        return false;
        //    }
        //    catch (Exception )
        //    {
        //       // CustomPrint.PrintInMagenta(e.Message);
        //        return false;
        //    }
        //}
        //UC19
        public bool GetDataFromCityAndState(AddressBookModel address)
        {
            try
            {
                List<AddressBookModel> list = new List<AddressBookModel>();
                SqlConnection sqlconnection = new SqlConnection(connectionString);
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spRetreiveTheData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(@"City", address.City);
                    cmd.Parameters.AddWithValue(@"State", address.State);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            address.ID = reader.GetInt32(0);
                            address.First_Name = reader.GetString(1);
                            address.Last_Name = reader.GetString(2);
                            address.Address = reader.GetString(3);
                            address.City = reader.GetString(4);
                            address.State = reader.GetString(5);
                            address.Zip = reader.GetInt64(6);
                            address.PhoneNumber = reader.GetInt64(7);
                            address.Email = reader.GetString(8);
                            address.Name = reader.GetString(9);
                            address.Type = reader.GetString(10);
                            list.Add(address);
                            Console.WriteLine(address.ID + "," + address.First_Name + "," + address.Last_Name + "," + address.Address + "," + address.City + ","
                                + address.State + "," + address.Zip + "," + address.PhoneNumber + "," + address.Email + "," + address.Name + "," + address.Type);
                        }
                        Console.WriteLine("The Number Of Address is: " + list.Count());
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }

        }
        //UC-20
        public bool AddContact(AddressBookModel address)
        {
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("Add_AddressBookContact", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@First_Name", address.First_Name);
                    sqlCommand.Parameters.AddWithValue("@Last_Name", address.Last_Name);
                    sqlCommand.Parameters.AddWithValue("@Address", address.Address);
                    sqlCommand.Parameters.AddWithValue("@City", address.City);
                    sqlCommand.Parameters.AddWithValue("@State", address.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", address.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", address.Email);
                    sqlCommand.Parameters.AddWithValue("@Name", address.Name);
                    sqlCommand.Parameters.AddWithValue("@Type", address.Type);
                    sqlConnection.Open();

                    var result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressBookException(AddressBookException.ExceptionType.Contact_Not_Add, "Contact are not added");
            }
        }
    }
}
