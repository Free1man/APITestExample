﻿using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTest.Tests
{
    [TestClass]
    public class MsTestExample
    {
        private readonly string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        [TestMethod]
        public void ValidateJsonMsTest()
        {
            const string endPoint = "v1/Categories/6327/Details.json?catalogue=false";
            var request = new RequestHandler();
            var parsedJson = request.GetJsonFromUrl(_apiUrl + endPoint).Result;
            
            var actualName = parsedJson.SelectToken("$.Name").ToString();
            Assert.AreEqual("Carbon credits", actualName);

            var actualRelistStatus = parsedJson.SelectToken("$.CanRelist").ToString();
            Assert.AreEqual("True", actualRelistStatus);

            var actualDescription = parsedJson.SelectToken("$.Promotions[?(@.Name=='Gallery')].Description").ToString();
            Assert.IsTrue(actualDescription.Contains("2x larger image"));
        }
    }

}
