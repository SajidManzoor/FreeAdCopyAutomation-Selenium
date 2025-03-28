using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;
using FreeAdCopyAutomation.PageObjects;
namespace FreeAdCopyAutomation.PageMethods
{
    public class DashboardMethods
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly DashBoardObjects _dashboardElement;
        private readonly LoginObjects _loginElements;
        //private readonly AdsPageMethods _adsPage;

        public DashboardMethods(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _dashboardElement = new DashBoardObjects(driver);
            _loginElements = new LoginObjects(driver);
            //_adsPage = new AdsPageMethods(driver);
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_driver.Url + "/dashboard");
            //Assert.IsTrue(_driver.Url.Contains("/dashboard"), "URL should include '/dashboard'");
            Assert.That(_driver.Url.Contains("/dashboard"), Is.True, "URL should include '/dashboard'");
        }

        public void SelectTemplateTab()
        {
            _dashboardElement.TemplateTab.Click();
            Assert.That(_driver.Url.Contains("/templates"), Is.True, "URL should include '/templates'");
        }

        public void SelectTemplateCategory()
        {
            _dashboardElement.TemplateCategory.Click();
        }

        public void SelectFBTemplate()
        {
            _dashboardElement.TemplateFb.Click();
        }

        // Email
        public void SelectEmailCategory()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".grid > .mt-4:nth-child(1)")));
            _dashboardElement.EmailCategory.Click();
            Assert.That(_driver.Url.Contains("/templates"), Is.True, "URL should include '/templates'");
        }

        public void SelectEmailSequence()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(":nth-child(4) > :nth-child(1) > .rotating-card-container")));
            _dashboardElement.EmailSequence.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("subcategory"));
            Assert.That(_driver.Url.Contains("subcategory"), Is.True, "URL should include 'subcategory'");
        }


        public void SelectEmailTemplate()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(":nth-child(1) > .rotating-card-container")));
            _dashboardElement.EmailTemplate.Click();
        }

        public void SelectTemplate(string templateName)
        {
            var template = _driver.FindElements(By.XPath($"//*[contains(text(), '{templateName}')]")).FirstOrDefault();
            template?.Click();
        }

        // YouTube
        public void SelectYoutubeCategory()
        {
            _dashboardElement.YoutubeCategory.Click();
            Assert.That(_driver.Url.Contains("/youtube-ads"), Is.True, "URL should include '/youtube-ads'");
            Assert.That(_dashboardElement.BredcrumbYoutube.Displayed, Is.True, "YouTube breadcrumb should be visible");
        }

        public void SelectYoutubeTemplate()
        {
            _dashboardElement.YoutubeTemplate.Click();
        }

        // Market Research
        public void SelectMarketResCategory()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".grid > .mt-4:nth-child(4)")));
            _dashboardElement.MarketResCategory.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/market-research"));
            Assert.That(_driver.Url.Contains("/market-research"), Is.True, "URL should include '/market-research'");
            //Assert.That(_dashboardElement.BredcrumbMarketRes.Displayed, Is.True, "Market Research breadcrumb should be visible");
        }

        public void SelectMarketResTemplate()
        {
            _dashboardElement.MarketTemplate.Click();
        }

        // Misc
        public void SelectMiscCategory()
        {
            _dashboardElement.MiscCategory.Click();
            Assert.That(_driver.Url.Contains("/misc"), Is.True, "URL should include '/misc'");
            Assert.That(_dashboardElement.BredcrumbMisc.Displayed, Is.True, "Misc breadcrumb should be visible");
        }

        public void SelectMiscTemplate()
        {
            _dashboardElement.MiscTemplate.Click();
        }

        // Advertorial
        public void SelectAdvertorialCategory()
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(_driver);
            actions.DoubleClick(_dashboardElement.AdvertorialCategory).Perform();
            Assert.That(_driver.Url.Contains("/advertorial"), Is.True, "URL should include '/advertorial'");
            Assert.That(_dashboardElement.BredcrumbAdvert.Displayed, Is.True, "Advertorial breadcrumb should be visible");
        }

        public void SelectAdvertorialTemplate()
        {
            _dashboardElement.AdvertorialTemplate.Click();
        }

        public void ClickProfileIcon()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".flex > .flex > .w-11")));
            Assert.That(_dashboardElement.ProfileIcon.Displayed, Is.True, "Profile icon should be visible");

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", _dashboardElement.ProfileIcon);

        }

        public void SelectSettingsTab()
        {
            _dashboardElement.SettingsTab.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/settings"));
            Assert.That(_driver.Url.Contains("/settings"), Is.True, "URL should include '/settings'");
        }

        public void SelectReportBugTab()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("ul > :nth-child(4)")));
            _dashboardElement.ReportBugTab.Click();
        }

        public void SelectSignoutTab()
        {
            _dashboardElement.SignoutTab.Click();
        }

        public void VerifyAd()
        {
            Assert.That(_dashboardElement.AdContent.Displayed, Is.True, "Ad content should be visible");
        }

        public void SelectMyAdsOption()
        {
            _dashboardElement.MyAdsOption.Click();
        }

        public void SelectSavedAd()
        {
            _dashboardElement.AdSelect.Click();
        }

        public void EditAd()
        {
            Assert.That(_dashboardElement.EditIcon.Displayed, Is.True, "Edit icon should be visible");
            _dashboardElement.EditIcon.Click();
        }

        public void SelectSaveBtn()
        {
            Assert.That(_dashboardElement.SaveBtn.Displayed, Is.True, "Save button should be visible");
            _dashboardElement.SaveBtn.Click();
        }

        public void ToastNotify(string toastMessage)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".Toastify__toast-body")));
            Assert.That(_loginElements.Toast.Text, Is.EqualTo(toastMessage), "Toast notification should match expected message");
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".Toastify__toast-body")));
        }

        public void SubmitBugReport(string bugDetail)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("message")));
            _dashboardElement.ReportBug.Click();
            _dashboardElement.ReportBug.SendKeys(bugDetail);
            _dashboardElement.ReportSubmitBtn.Click();
        }

        public void SelectLearningTab()
        {
            _dashboardElement.LearningTab.Click();
        }

        public void SelectVideo()
        {
            //_dashboardElement.FreeVideo.Click();
            //Assert.That(_driver.Url.Contains("/course"), Is.True, "URL should include '/course'");

            //_driver.Navigate().Refresh();

            //var video = _wait.Until(driver => driver.FindElement(By.TagName("video")));
            //Assert.That(video.Displayed, Is.True, "Video should be visible");

            //// Check video state using JavaScript
            //var js = (IJavaScriptExecutor)_driver;
            //Assert.AreEqual(4, js.ExecuteScript("return arguments[0].readyState", video), "Video should be ready");
            //Assert.AreEqual(true, js.ExecuteScript("return arguments[0].paused", video), "Video should be paused");
            //Assert.AreEqual(false, js.ExecuteScript("return arguments[0].ended", video), "Video should not be ended");

            //// Play the video using JavaScript
            //js.ExecuteScript("arguments[0].play()", video);

            //// Verify video is playing
            //Assert.AreEqual(false, js.ExecuteScript("return arguments[0].paused", video), "Video should not be paused after play");
            //Assert.AreEqual(false, js.ExecuteScript("return arguments[0].ended", video), "Video should not be ended");
            _dashboardElement.FreeVideo.Click();
            Assert.That(_driver.Url.Contains("/course"), Is.True, "URL should include '/course'");

            _driver.Navigate().Refresh();

            var video = _wait.Until(driver => driver.FindElement(By.TagName("video")));
            Assert.That(video.Displayed, Is.True, "Video should be visible");

            var js = (IJavaScriptExecutor)_driver;
            Assert.That(js.ExecuteScript("return arguments[0].readyState", video), Is.EqualTo(4), "Video should be ready");
            Assert.That(js.ExecuteScript("return arguments[0].paused", video), Is.EqualTo(true), "Video should be paused");
            Assert.That(js.ExecuteScript("return arguments[0].ended", video), Is.EqualTo(false), "Video should not be ended");

            js.ExecuteScript("arguments[0].play()", video);

            Assert.That(js.ExecuteScript("return arguments[0].paused", video), Is.EqualTo(false), "Video should not be paused after play");
            Assert.That(js.ExecuteScript("return arguments[0].ended", video), Is.EqualTo(false), "Video should not be ended");

        }

        public void SearchTemplate()
        {
            _dashboardElement.SearchBar.Click();
        }

        public void EnterTemplate(string template)
        {
            _dashboardElement.SearchField.SendKeys(template);
            _driver.FindElement(By.CssSelector(".mx-2 > :nth-child(1) > .cursor-pointer > .flex")).Click();
            Assert.That(_driver.FindElement(By.CssSelector(".text-\\[16px\\]")).Text.Contains(template), Is.True, "Search result should contain the template name");
        }

        public void SelectNewestTemplate()
        {
            _dashboardElement.NewestTemplate.Click();
        }

        //public void SelectNew(string targetMarket, string painPoint, string dislikeSol, string uniqueSol)
        //{
        //    var newestElements = _driver.FindElements(By.CssSelector(_dashboardElement.NewestSelector));
        //    for (int i = 1; i <= newestElements.Count; i++)
        //    {
        //        _driver.FindElement(By.CssSelector(_dashboardElement.NewestTemplateSelector(i))).Click();
        //        _adsPage.FillAdsForm(targetMarket, painPoint, dislikeSol, uniqueSol);
        //        _driver.FindElement(By.CssSelector(".rt-reset")).Click();

        //        var selectElement = new SelectElement(_driver.FindElements(By.TagName("select")).First());
        //        selectElement.SelectByValue("en");

        //        _adsPage.SelectGenerateAdBtn();
        //        VerifyAd();

        //        _driver.FindElement(By.CssSelector(".space-y-4>.flex-1 > a:nth-child(1)")).Click();
        //    }
        //}

        public void VerifyDashboardLanguage(string language = "en")
        {
            Assert.That(_driver.Url.Contains("/dashboard"), Is.True, "URL should include '/dashboard'");

            var greetings = new Dictionary<string, string>
            {
                {"en", "Good"},
                {"es", "Bien"},
                {"fr", "Bien"},
                {"de", "Gut"},
                {"it", "Buono"},
                {"pt", "Bom"},
                {"idn", "Baik"},
                {"ru", "Отлично"},
                {"pol", "Dobry"},
                {"uk", "Добре"}
            };

            Assert.That(_dashboardElement.GreetingsText.Text.Contains(greetings[language]), Is.True,$"Greeting should contain '{greetings[language]}'");
        }

        public void SelectFirstTemplate()
        {
            _dashboardElement.FirstTemplate.Click();
        }

        public string GetCreditsCount()
        {
            Assert.That(_dashboardElement.CreditsText.Displayed, Is.True, "Credits text should be visible");
            return _dashboardElement.CreditsText.Text;
        }

        public void ClickBuyCredits()
        {
            _dashboardElement.BuyCreditsBtn.Click();
        }

        public void CheckCreditsDifference(string previousCredits, int difference)
        {
            string previousAmount = previousCredits.Split(' ')[0];
            int previousValue = int.Parse(previousAmount);
            int expectedValue = previousValue + difference;

            Assert.That(_dashboardElement.CreditsText.Displayed, Is.True, "Credits text should be visible");
            Assert.That(_dashboardElement.CreditsText.Text, Is.EqualTo($"{expectedValue} Credits"), "Credits should be updated correctly");
        }

        public void CheckCreditsIncrease(string previousCredits)
        {
            string previousAmount = previousCredits.Split(' ')[0];
            int previousValue = int.Parse(previousAmount);

            Assert.That(_dashboardElement.CreditsText.Displayed, Is.True, "Credits text should be visible");
            int currentValue = int.Parse(_dashboardElement.CreditsText.Text.Split(' ')[0]);
            Assert.That(currentValue > previousValue + 1, Is.True, "Credits should have increased by more than 1");
        }
    }
}
