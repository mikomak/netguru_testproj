using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestProj
{
    class Actions : Setup
    {

        public static void GoToLoginPage()
        {
            driver.FindElementByCssSelector(StaticPageElements.createAccOrLogInElement).Click();
        }

        public static void ClickOffToChangeFocus()
        {
            driver.FindElementByCssSelector(StaticPageElements.conditionsAndTermsElement).Click();
        }

        public static void ClickLoginButton()
        {
            driverExtensions.WaitForDisplayedElement(By.CssSelector(StaticPageElements.loginButton)).Click();
        }

        public static void ClickRegisterButton()
        {
            driverExtensions.WaitForDisplayedElement(By.CssSelector(StaticPageElements.registerButton)).Click();
        }

        public static void AssertErrorElementDisplayed()
        {
            IWebElement errorElementOnLoginPane = driverExtensions.WaitForDisplayedElement(By.CssSelector(StaticPageElements.loginFormErrorMessageElement));

            if (!errorElementOnLoginPane.Displayed)
            {
                Assert.Fail("The error element was not displayed");
            }
        }

        public static void AssertStillOnTheSamePage(string url)
        {
            string currentUrl = driver.Url;

            if (currentUrl != url)
            {
                Assert.Fail("URL changed - should be: " + url + " but is " + currentUrl);
            }
        }

        public static void AssertLoggedIn()
        {
            string currentUrl = driver.Url;

            if (currentUrl != "https://www.olx.pl/mojolx/#login")
            {
                Assert.Fail("User didn't log in - is at url: " + currentUrl);
            }
        }


    }
}
