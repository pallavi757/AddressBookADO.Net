﻿using System;
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
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("dbo.spGetAllAddressBookData", sqlConnection);
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
                sqlConnection.Close();

            }
            return list;
        }//UC 17-update contact
        public static bool UpdateContact(AddressBookModel address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.EditContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_Name", address.First_Name);
                    command.Parameters.AddWithValue("@Last_Name", address.Last_Name);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    command.Parameters.AddWithValue("@Zip", address.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", address.Email);
                    command.Parameters.AddWithValue("@Type", address.Type);
                    command.Parameters.AddWithValue("@Name", address.Name);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressBookException(AddressBookException.ExceptionType.Contact_Not_Updated, "Contact not updated");
                return false;
            }
        }

    }
}
