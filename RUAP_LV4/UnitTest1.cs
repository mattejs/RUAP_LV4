using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCase1Test()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//nav[@id='top']/div")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Test");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("User");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("testuser@demo.com");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("123456789");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("test");
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("test");
            driver.FindElement(By.XPath("//div[@id='content']/form/fieldset[3]/div/div")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/fieldset[3]/div/div/label")).Click();
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("testuser1@demo.com");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
        }

        [Test]
        public void TheCase2Test()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("testuser@demo.com");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        [Test]
        public void TheCase3Test()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        [Test]
        public void TheCase4Test()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.LinkText("Desktops")).Click();
            driver.FindElement(By.LinkText("Mac (1)")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/div/div/div[2]/div[2]/button/span")).Click();
        }
        [Test]
        public void TheCase5Test()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.LinkText("Monitors (2)")).Click();
            driver.FindElement(By.LinkText("Samsung SyncMaster 941BW")).Click();
            driver.FindElement(By.Id("input-quantity")).Click();
            driver.FindElement(By.Id("input-quantity")).Clear();
            driver.FindElement(By.Id("input-quantity")).SendKeys("2");
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[5]/a/i")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Checkout')]")).Click();
        }
            private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}