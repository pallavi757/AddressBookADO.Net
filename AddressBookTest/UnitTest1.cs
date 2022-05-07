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
            addressBookModel.Type = "FirendGroup";
            addressBookModel.Name = "Frined";
            bool result = Details.UpdateContact(addressBookModel);
            Assert.AreEqual(expected, result);
        }
        /// UC - Get data from city and state
        [Test]
        public void Get_Data_ByUsingCityAndState()
        {
            bool expected = true;
            addressBookModel.City = "Mumbai";
            addressBookModel.State = "Maharashtra";
            bool result = details.GetDataFromCityAndState(addressBookModel);
            Assert.AreEqual(expected, result);
        }
        //UC-Add Contact
        [Test]
        public void Add_AddressBook_ContactInDB()
        {
            bool expected = true;
            addressBookModel.First_Name = "Raju";
            addressBookModel.Last_Name = "Wayal";
            addressBookModel.Address = "Street 45";
            addressBookModel.City = "Haydrabad";
            addressBookModel.State = "Telangana";
            addressBookModel.Zip = 940045;
            addressBookModel.PhoneNumber = 9805310008;
            addressBookModel.Email = "raju13@gmail.com";
            addressBookModel.Name = "Friend";
            addressBookModel.Type = "FriendGroup";
            bool result = details.AddContact(addressBookModel);
            Assert.AreEqual(expected, result);
        }
    }
}