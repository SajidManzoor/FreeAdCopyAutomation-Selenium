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

        public LoginMethods(IWebDriver driver)
        {
            _driver = driver;
            _elements = new LoginObjects(driver);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Adjust timeout as needed
        }
        public void ClickLoginNavbar()
        {
            _elements.Login_Navbar.Click();
        }

        public void EnterEmail(string email)
        {
            _elements.EmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            _elements.PasswordField.SendKeys(password);
        }

        public void SigninBtn()
        {
            _elements.SigninBtn.Click();
        }

        public void LoginValidation()
        {
            //_wait.Until(SeleniumExtras.ExpectedConditions.ElementIsVisible(By.CssSelector(".p-4 > .text-2xl")));
            _wait.Until(driver =>
            {
                var element = driver.FindElement(By.CssSelector(".p-4 > .text-2xl"));
                return element.Displayed ? element : null;
            });

            Assert.That(_elements.WelcomeText.Displayed, Is.True);
        }

        public void ToastNotification(string toastMessage)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
            //Assert.AreEqual(toastMessage, _elements.Toast.Text);
            Assert.That(_elements.Toast.Text,Is.EqualTo(toastMessage));
        }

        public void LoginBtnValidation()
        {
            Assert.That(_elements.SigninBtn.Enabled,Is.False);
        }

        public void SelectTemplate()
        {
            _elements.TemplateOption.Click();
        }

        public void SelectField(string field)
        {
            // Assuming you have a field to type into, similar to the email/password fields
            // You'll need to add the selector for this field in LoginPageElements.cs
            // Example: _elements.TargetField.SendKeys(field);
            // You need to add target_Field in LoginPageElements.cs
            IWebElement targetField = _driver.FindElement(By.Id("target_field_id"));
            targetField.SendKeys(field);
        }

        public void SelectButton()
        {
            // Assuming you have a button to click, similar to the sign-in button
            // You'll need to add the selector for this button in LoginPageElements.cs
            // Example: _elements.GenerateBtn.Click();
            // You need to add generate_Btn in LoginPageElements.cs
            IWebElement generateBtn = _driver.FindElement(By.Id("generate_btn_id"));
            generateBtn.Click();
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
            Assert.That(_elements.Toast.Text, Is.EqualTo(toastMessages[language]));
        }

        public void ClickGoogleSignin()
        {
            // You need to add google_signin_btn in LoginPageElements.cs
            IWebElement googleSigninBtn = _driver.FindElement(By.Id("google_signin_btn_id"));
            googleSigninBtn.Click();
        }

        public void VerifyLoginFailure(string language = "en")
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
            Assert.That(_elements.Toast.Text, Is.EqualTo(toastMessages[language]));
        }
    }
}
