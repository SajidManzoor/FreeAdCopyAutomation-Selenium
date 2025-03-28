using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
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

        //private readonly Utilities _utilities; // Assuming you have a Utilities class
        public SettingsMethods(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _settingsElements = new SettingsObjects(driver);
            _loginElements = new LoginObjects(driver); 
            _dashboardElements = new DashBoardObjects(driver); 
            //_utilities = new Utilities(); // Assuming you have a Utilities class
        }

        public void UpdateUsername(string username)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("text")));
            _settingsElements.UserNameField.Clear();
            _settingsElements.UserNameField.SendKeys(username);
            _settingsElements.UpdateSettingsButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(_settingsElements.UserNameField));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
            //_driver.Navigate().Refresh();
            //_wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("text")));

            //Assert.That(_settingsElements.UserNameField.GetAttribute("value"), Is.EqualTo(username));
            
        }


        //    public void UpdateNotification()
        //    {
        //        //This needs adjustment based on how the toast message is handled in your application.
        //        //Example using explicit wait:
        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //        IWebElement toast = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
        //        Assert.IsTrue(toast.Text.Contains("Profile Updated"));

        //    }

        public void PasswordSettingTab()
        {
            _settingsElements.PasswordSettingTab.Click();
        }

        public void UpdatePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            //_settingsElements.PasswordSettingTab.Click();
            //_settingsElements.ScrollToElement(_settingsElements.UpdatePasswordButton);
            //_wait.Until(ExpectedConditions.ElementToBeClickable(_settingsElements.PasswordField));
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("text")));
            _driver.FindElement(By.Id("text")).SendKeys(Keys.PageDown);
            _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", _settingsElements.PasswordField);
            _settingsElements.PasswordField.Clear();
            _settingsElements.PasswordField.SendKeys(currentPassword);
            _settingsElements.ConfirmPasswordField.SendKeys(confirmPassword);
            _settingsElements.NewPasswordField.Clear();
            _settingsElements.NewPasswordField.SendKeys(newPassword);
            
        }

        public void ClickUpdatePasswordButton()
        {
            _settingsElements.UpdatePasswordButton.Click();
        }

        //    public void VerifyPasswordUpdate()
        //    {
        //        //This needs adjustment based on how the toast message is handled in your application.
        //        //Example using explicit wait and checking for absence of text:
        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //        try
        //        {
        //            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body > :nth-child(2)")));
        //            Assert.IsFalse(_loginPageElements.Toast.Text.Contains("Password Updated"));
        //        }
        //        catch (NoSuchElementException)
        //        {
        //            //Toast message not found, which might be expected if password update failed.
        //            //Handle this case appropriately in your test.
        //        }
        //    }

        //    public void SelectLanguage(string language)
        //    {
        //        _settingsPageElements.LanguageDropdown.Click();
        //        //This needs adjustment based on how the language options are structured in your application.
        //        //Example using explicit wait:
        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //        IWebElement languageItem = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id($"menu-item-{language}")));
        //        languageItem.Click();
        //    }

        //    public void VerifyLanguage(string language)
        //    {
        //        var lang = new Dictionary<string, string>
        //        {
        //            { "en", "Account Settings" },
        //            { "es", "Configuración de cuenta" },
        //            { "fr", "Paramètres du compte" },
        //            { "de", "Kontoeinstellungen" },
        //            { "it", "Impostazioni Account" },
        //            { "pt", "Configurações da Conta" },
        //            { "idn", "Pengaturan Akun" },
        //            { "ru", "Настройки аккаунта" },
        //            { "pol", "Ustawienia konta" },
        //            { "uk", "Налаштування облікового запису" }
        //        };
        //        Assert.AreEqual(lang[language], _settingsPageElements.AccountSettingsText.Text);
        //    }

        //    public void SelectTab(string tab)
        //    {
        //        foreach (IWebElement tabElement in _settingsPageElements.TabList)
        //        {
        //            if (tabElement.Text.Contains(tab))
        //            {
        //                tabElement.Click();
        //                break;
        //            }
        //        }
        //    }

        //    public void ClickUpgradePlan()
        //    {
        //        _settingsPageElements.UpgradePlanButton.Click();
        //    }

        //    public void SelectAnyPlan()
        //    {
        //        //This needs adjustment based on how the upgrade buttons are structured.
        //        //The original Cypress code is not very robust.  Consider using more specific locators.
        //        ReadOnlyCollection<IWebElement> upgradeButtons = _settingsPageElements.UpgradeButtonList;
        //        if (upgradeButtons.Count > 0)
        //        {
        //            upgradeButtons[0].Click();
        //        }
        //        else
        //        {
        //            throw new Exception("No upgrade buttons found.");
        //        }
        //    }

        //    public void CheckCreditsDifference(string alias, string difference)
        //    {
        //        //This requires significant adaptation to your specific application's structure and how credits are displayed.
        //        //The original Cypress code relies heavily on implicit waits and assumptions about the page structure.
        //        //You'll need to replace this with more robust and explicit waits and locators.
        //        //Example using explicit wait:
        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //        wait.Until(ExpectedConditions.ElementToBeClickable(_dashboardElements.CreditsText)); // Assuming you have a CreditsText property in DashboardElements

        //        string initialCredits = _dashboardElements.CreditsText.Text;
        //        _driver.Navigate().GoToUrl("/dashboard"); //Simulate cy.visit
        //        wait.Until(ExpectedConditions.ElementToBeClickable(_dashboardElements.CreditsText));
        //        string finalCredits = _dashboardElements.CreditsText.Text;

        //        //Parse credits from the text (adapt to your specific format)
        //        int initialCreditValue = int.Parse(initialCredits.Split(" ")[0]);
        //        int finalCreditValue = int.Parse(finalCredits.Split(" ")[0]);

        //        Assert.AreEqual(initialCreditValue + int.Parse(difference), finalCreditValue);
        //    }
    }
}
