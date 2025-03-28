using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  OpenQA.Selenium;

namespace FreeAdCopyAutomation.PageObjects
{
    public class LoginObjects
    {
        private readonly IWebDriver _driver;
        public LoginObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement Login_Navbar => _driver.FindElement(By.CssSelector(".-top-50 > .text-\\[16px\\]"));
        public IWebElement EmailField => _driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement SigninBtn => _driver.FindElement(By.CssSelector("button[type='submit']"));
        //public IWebElement Toast => _driver.FindElement(By.CssSelector(".Toastify__toast-body > :nth-child(2)"));
        public IWebElement Toast => _driver.FindElement(By.CssSelector(".Toastify__toast-body"));
        public IWebElement WelcomeText => _driver.FindElement(By.CssSelector(".p-4 > .text-2xl"));
        public IWebElement TemplateOption => _driver.FindElement(By.CssSelector(".flex-1 > a:nth-child(3)"));
    }
}
