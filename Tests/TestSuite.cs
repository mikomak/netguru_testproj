using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestProj;

namespace TestProj
{
    public class Tests : Setup
    {

        [SetUp]
        public void Initialize()
        {
            ChromeDriverSetup();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void TS01_T01_CheckErrorMessagesForWrongEmailsOnLogin()
        {
            Actions.GoToLoginPage();
            driverExtensions.SendKeysToDisplayedElementByCss(StaticPageElements.emailLoginElement, "d");
            Actions.ClickOffToChangeFocus();
            Actions.AssertErrorElementDisplayed();
            string url = driver.Url;
            Actions.ClickLoginButton();
            Actions.AssertStillOnTheSamePage(url);
        }

        [Test]
        public void TS01_T02_CheckWhitespaceRecognitionInPassword()
        {
            Actions.GoToLoginPage();
            driverExtensions.SendKeysToDisplayedElementByCss(StaticPageElements.emailLoginElement, "guruofthenet.test@gmail.com");
            driverExtensions.SendKeysToDisplayedElementByCss(StaticPageElements.passwordLoginElement, "Netguru 4 2 0");
            string url = driver.Url + "#login";
            Actions.ClickLoginButton();
            Actions.AssertErrorElementDisplayed();
            Actions.AssertStillOnTheSamePage(url);
            driverExtensions.SendKeysToDisplayedElementByCss(StaticPageElements.passwordLoginElement, "Netguru420");
            Actions.ClickLoginButton();
            Actions.AssertLoggedIn();
        }
    }
}