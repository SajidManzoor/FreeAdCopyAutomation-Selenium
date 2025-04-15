using OpenQA.Selenium;

namespace FreeAdCopyAutomation.PageObjects
{
    public class LoginObjects
    {
        private readonly IWebDriver _driver;
        public LoginObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        public By Login_Navbar => By.CssSelector(".-top-50 > .text-\\[16px\\]");
        public By EmailField => By.Id("email");
        public By PasswordField => By.Id("password");
        public By SigninBtn => By.CssSelector("button[type='submit']");
        public By Toast => By.CssSelector(".Toastify__toast-body");
        public By WelcomeText => By.CssSelector(".p-4 > .text-2xl");
        public By TemplateOption => By.CssSelector(".flex-1 > a:nth-child(3)");
    }
}
