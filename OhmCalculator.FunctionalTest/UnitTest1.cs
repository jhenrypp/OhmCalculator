using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using OhmCalculator.Web;
using OhmCalculator.Web.Models;
using System;
using System.Net.Http;
using Xunit;

namespace OhmCalculator.FunctionalTest
{


    public class OhmCalculatorAPITest
    {
        readonly TestServer testServer;
        HttpClient Client;
        public OhmCalculatorAPITest()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            testServer = new TestServer(webHostBuilder);
        }


        [Theory]
        [InlineData("red", "green", "blue","red")]
        [InlineData("blue", "green", "blue", "red")]
        [InlineData("yellow", "green", "blue", "red")]
        public async void Calculate(string bandColorA, string bandColorB, string bandColorC, string bandColorD)
        {
            //Arrange
            Client = testServer.CreateClient();
            //Act
            var response=await Client.GetAsync($"./api/ohmCalculator/{bandColorA}/{bandColorB}/{bandColorC}/{bandColorD}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResistantResult>(responseString);
            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("black", "green", "blue", "red")]
        [InlineData("blue", "green", "blue", "black")]
        [InlineData("yellow", "green", "purple", "red")]
        public async void InvalidColorTest(string bandColorA, string bandColorB, string bandColorC, string bandColorD)
        {
            //Arrange
            Client = testServer.CreateClient();
            //Act
            var response = await Client.GetAsync($"./api/ohmCalculator/{bandColorA}/{bandColorB}/{bandColorC}/{bandColorD}");
            
            var responseString = await response.Content.ReadAsStringAsync();

            
            //Assert
            Assert.Contains("Invalid color for band", responseString);
        }
    }
}
