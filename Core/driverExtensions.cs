using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.IO;

namespace TestProj
{
    static class driverExtensions
    {
        public static IWebElement WaitForElement(By by, int timeoutInSeconds = 20, string nullableErrorMessage = null)
        {
            try
            {
                var wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
                return wait.Until(drv => drv.FindElement(by));
            }
            catch (Exception)
            {
                Assert.Fail(nullableErrorMessage + "\n" + timeoutInSeconds + "sec TIMEOUT on waiting for " + " element " + by.ToString());
                return null;
            }
        }

        public static IWebElement WaitForDisplayedElement(By by, int timeoutInSec = 10, string message = "", bool failIfNotFound = true)
        {
            var wait = new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(timeoutInSec));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(ElementNotInteractableException));

            try
            {
                var element = wait.Until(ElementIsClickable(by));
                if (element != null)
                    return element;
            }
            catch (WebDriverTimeoutException)
            {
                if (failIfNotFound)
                    Assert.Fail(timeoutInSec + "sec timeout. " + message + "\nCant find displayed element by: " + by);
                else
                {
                    Console.WriteLine(message);
                    return null;
                }
            }
            return null;
        }

        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var elements = driver.FindElements(locator);
                foreach (IWebElement element in elements)
                {
                    if (element != null && element.Displayed && element.Enabled)
                        return element;
                }
                return null;
            };
        }

        public static void SendKeysToDisplayedElementByCss(string elementCssSelector, string keysText)
        {
            IWebElement element = WaitForDisplayedElement(By.CssSelector(elementCssSelector));
            element.Click();
            element.SendKeys(keysText);
        }
    }
}
