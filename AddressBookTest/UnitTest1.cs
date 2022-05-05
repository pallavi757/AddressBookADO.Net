using AddressBookSystem;
using NUnit.Framework;

namespace AddressBookTest
{
    public class Tests
    {
        Details details;
        AddressBookModel addressBookModel;
        [SetUp]
        public void Setup()
        {
            details = new Details();
            addressBookModel = new AddressBookModel();
        }
        /// UC -Get all the Address Book Data 
        [Test]
        public void RetriveContactsFromDB()
        {
            var expected =6;
            var result = Details.GetAddressBookDetails();
            Assert.AreEqual(expected,result.Count);
        }
    
       // [Test]
        //public void UpdateContactInDB_ShouldReturn_False_IfContactsNotFound()
        //{
        //    bool expected = false;
        //    AddressBookModel modelObj = new AddressBookModel();
        //    addressBookModel.First_Name = "Sandip";
        //    addressBookModel.Last_Name = "Mehta";
        //    addressBookModel.Address = "Lane 4";
        //    addressBookModel.City = "Mumbai";
        //    addressBookModel.State = "Maharashtra";
        //    addressBookModel.Zip = 489856;
        //    addressBookModel.PhoneNumber = 9923991299;
        //    addressBookModel.Email = "sm123@gmail.com";
        //    addressBookModel.Type = "Firend";
        //    addressBookModel.Name = "FrinedGroup";
        //    bool result = Details.UpdateContact(addressBookModel);
        //    Assert.AreEqual(expected, result);

        //}
        /// UC - Update the Address Book Contact In DataBase
        [Test]
        public void UpdateContactInDB_ShouldReturn_True_IfContactFound_And_ContactGotUpdated()
        {
            bool expected = true;
            addressBookModel.First_Name = "Sandip";
            addressBookModel.Last_Name = "Mehta";
            addressBookModel.Address = "Lane 4";
            addressBookModel.City = "Nanded";
            addressBookModel.State = "Maharashtra";
            addressBookModel.Zip = 489856;
            addressBookModel.PhoneNumber = 9923991299;
            addressBookModel.Email = "sm123@gmail.com";
            addressBookModel.Type = "Firend";
            addressBookModel.Name = "FrinedGroup";
            bool result = Details.UpdateContact(addressBookModel);
            Assert.AreEqual(expected, result);
        }
    }
}