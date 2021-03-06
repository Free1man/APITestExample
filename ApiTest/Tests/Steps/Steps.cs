﻿using TechTalk.SpecFlow;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace ApiTest.Tests.Steps
{
    [Binding]
    public sealed class Steps
    {

        private readonly string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private JToken _parsedJson;

        [StepDefinition(@"I send a request to (.*)")]
        public async Task WhenISendARequestTo(string endPoint)
        {
            var client = new RequestHandler();
            _parsedJson = await client.GetJsonFromUrl(_apiUrl + endPoint);
        }

        [StepDefinition(@"I should see value in the response at specific path")]
        public void IShouldSeeValueInTheResponseAtSpecificPath(Table table)
        {
            foreach (var row in table.Rows)
            {
                var jsonPath = row[0];
                var expected = row[1];
                var nodeValue = _parsedJson.SelectToken(jsonPath).ToString();
                Assert.AreEqual(expected, nodeValue, $"Value received: {nodeValue} is not matching expected value: {expected}.");
            }
        }

        [StepDefinition(@"Value in the response at specific path should contain")]
        public void ValueInTheResponseAtSpecificPathShouldContain(Table table)
        {
            foreach (var row in table.Rows)
            {
                var jsonPath = row[0];
                var expected = row[1];
                var nodeValue = _parsedJson.SelectToken(jsonPath).ToString();
                Assert.IsTrue(nodeValue.Contains(expected), $"Value received: {nodeValue} does not contain expected value: {expected}.");
            }
        }

    }
}
