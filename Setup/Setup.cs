using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text;

namespace TestProj
{
    public class Setup
    {
        public static ChromeDriver driver { get; set; }

        public static void ChromeDriverSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://olx.pl");

            IJavaScriptExecutor jse = (IJavaScriptExecutor) driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => jse.ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
