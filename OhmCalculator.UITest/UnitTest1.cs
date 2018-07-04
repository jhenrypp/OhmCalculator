using OhmCalculator.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace OhmCalculator.UITest
{
    public class UIIntegrationTest
    {
        /// <summary>
        /// Change this url if the app url change.
        /// </summary>
        string testUrl = @"http://localhost:50337/";

        [Theory]
        [InlineData("red", "green", "blue", "red")]
        [InlineData("blue", "green", "blue", "red")]
        [InlineData("yellow", "green", "blue", "red")]
        public void Test1(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var driver = new ChromeDriver(Directory.GetCurrentDirectory());
            
                driver.Navigate().GoToUrl(testUrl);
            ((IJavaScriptExecutor)driver).ExecuteScript($"$('#dlBandA').val('{bandAColor}');$('#dlBandB').val('{bandBColor}');$('#dlBandC').val('{bandCColor}');$('#dlBandD').val('{bandDColor}');");


            var link = driver.FindElementById("btnCalculate");
                link.Click();
                var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            object result = "";
            wait.Until(drv=> {
                var txtResistance = driver.FindElement(By.Id("txtResistance"));
                result = txtResistance.GetAttribute("value");
                return result.ToString() != "";
            });
            Assert.NotEmpty(result.ToString());
            driver.Close();
        }


    }
}
