using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using FreeAdCopyAutomation.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace FreeAdCopyAutomation.PageMethods
{
    public class LoginMethods
    {
        private readonly IWebDriver _driver;
        private readonly LoginObjects _elements;
        private readonly WebDriverWait _wait;
        private readonly Utilities _utils;

        public LoginMethods(IWebDriver driver)
        {
            _driver = driver;
            _elements = new LoginObjects(driver);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _utils = new Utilities(driver);
        }
        public void ClickLoginNavbar()
        {
            _utils.Click(_elements.Login_Navbar);
        }

        public void EnterEmail(string email)
        {
            _utils.EnterText(_elements.EmailField, email);
        }

        public void EnterPassword(string password)
        {
            _utils.EnterText(_elements.PasswordField, password);
        }

        public void SigninBtn()
        {
            _utils.Click(_elements.SigninBtn);
        }

        public void LoginValidation()
        {
            _wait.Until(driver =>
            {
                var element = driver.FindElement(By.CssSelector(".p-4 > .text-2xl"));
                return element.Displayed ? element : null;
            });

            Assert.That(_driver.FindElement(_elements.WelcomeText).Displayed, Is.True);
        }

        public void ToastNotification(string toastMessage)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
            Assert.That(_driver.FindElement(_elements.Toast).Text, Is.EqualTo(toastMessage));
        }

        public void VerifyLoginToast(string language = "en")
        {
            Dictionary<string, string> toastMessages = new Dictionary<string, string>()
            {
                { "en", "Login successfully" },
                { "es", "Inicio de sesión exitoso" },
                { "fr", "Connexion réussie" },
                { "de", "Anmeldung erfolgreich" },
                { "it", "Accesso riuscito" },
                { "pt", "Login realizado com sucesso" },
                { "idn", "Login berhasil" },
                { "ru", "Connexion réussie" },
                { "pol", "Pomyślnie zalogowano" },
                { "uk", "Успішний вхід" }
            };
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
            Assert.That(_driver.FindElement(_elements.Toast).Text, Is.EqualTo(toastMessages[language]));
        }
    }
}
