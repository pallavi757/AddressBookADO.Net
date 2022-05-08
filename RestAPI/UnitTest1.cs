using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace RestAPI
{
    //class Contact
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //   // public string lastName { get; set; }
    //    public string Address { get; set; }
    //}
    [TestClass]
    public class UnitTest1
    {
        RestClient client = new RestClient("http://localhost:3000");
        private RestResponse GetAddressBookList()
        {
            RestRequest request = new RestRequest("/Address", Method.Get);
            //act
            RestResponse response = client.GetAsync(request).Result;
            return response;
        }
        /// <summary>
        /// Test method to check the contact list retrieved from json server
        /// </summary>
        [TestMethod]
        public void OnCallingGetApi_ReturnAddressList()
        {
            RestResponse response = GetAddressBookList();
            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(5, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine("Id: " + item.id + " First_Name: " + item.name  +" name: " + " Address: " + item.Address);
            }
        }
        /// <summary>
        /// Test method to check multiple contacts added to json server
        /// </summary>
        //[TestMethod]
        //public void GivenMultipleContacts_WhenPosted_ShouldReturnContactListWithAddedContacts()
        //{
        //    //arrange
        //    List<Contact> list = new List<Contact>();
        //    list.Add(new Contact { name = "John", Address = "California" });
        //    list.Add(new Contact { name = "Divya", Address = "Allahabad" });
        //    foreach (Contact contact in list)
        //    {
        //        //act
        //        RestRequest request = new RestRequest("/Address/create", Method.Post);
        //        JObject jObject = new JObject();
        //        jObject.Add("Name", contact.name);
        //        jObject.Add("Address", contact.Address);
        //        request.AddParameter("application/json", jObject, ParameterType.RequestBody);
        //        RestResponse response = client.Execute(request);
        //        //Assert
        //        Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        //        Contact dataResponse = JsonConvert.DeserializeObject<Contact>(response.Content);
        //        Assert.AreEqual(contact.name, dataResponse.name);
        //        Assert.AreEqual(contact.Address, dataResponse.Address);
        //    }
        //}
    }
}