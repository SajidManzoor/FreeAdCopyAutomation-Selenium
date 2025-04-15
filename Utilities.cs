using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FreeAdCopyAutomation
{
    class Utilities
    {
        private readonly IWebDriver _driver;

        Random random = new Random();

        public Utilities(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void Click(By element)
        {
            _driver.FindElement(element).Click();
        }
        public void EnterText(By element, string text)
        {
            _driver.FindElement(element).Clear();
            _driver.FindElement(element).SendKeys(text);
        }

    }
}
