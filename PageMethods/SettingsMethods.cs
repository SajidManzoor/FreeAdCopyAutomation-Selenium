using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using FreeAdCopyAutomation.PageObjects;
using OpenQA.Selenium.Support.Extensions;


namespace FreeAdCopyAutomation.PageMethods
{
    class SettingsMethods
    {
        private readonly IWebDriver _driver;

        private readonly SettingsObjects _settingsElements;
        private readonly WebDriverWait _wait;

        private readonly LoginObjects _loginElements;
        private readonly DashBoardObjects _dashboardElements;

        private readonly Utilities _utils;
        public SettingsMethods(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _settingsElements = new SettingsObjects(driver);
            _loginElements = new LoginObjects(driver);
            _dashboardElements = new DashBoardObjects(driver);
            _utils = new Utilities(driver);
        }

        public void UpdateUsername(string username)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("text")));
            _utils.EnterText(_settingsElements.UserNameField, username);
            _utils.Click(_settingsElements.UpdateSettingsButton);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(_settingsElements.UserNameField));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
        }

        public void UpdatePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("text")));
            _driver.FindElement(By.Id("text")).SendKeys(Keys.PageDown);
            _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", _driver.FindElement(_settingsElements.PasswordField));
            _utils.EnterText(_settingsElements.PasswordField, currentPassword);
            _utils.EnterText(_settingsElements.ConfirmPasswordField, confirmPassword);
            _utils.EnterText(_settingsElements.NewPasswordField, newPassword);
        }

        public void ClickUpdatePasswordButton()
        {
            _utils.Click(_settingsElements.UpdatePasswordButton);
        }

    }
}
