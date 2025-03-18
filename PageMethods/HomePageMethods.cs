using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using FreeAdCopyAutomation.PageObjects;

namespace FreeAdCopyAutomation.PageMethods
{
    public class HomePageMethods
    {
        private readonly IWebDriver _driver;
        private readonly HomePageObjects _elements;
        private readonly WebDriverWait _wait;

        public HomePageMethods(IWebDriver driver)
        {
            _driver = driver;
            _elements = new HomePageObjects(driver);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigationToLogin()
        {
            _elements.LoginNavbar.Click();
        }

        public void NavigationToSignup()
        {
            _elements.LoginNavbar.Click();
            _elements.SignupButton.Click();
        }

        public void ClickGetStarted()
        {
            _elements.GetStartedNav.Click();
        }

        public void ClickGetStartedButton()
        {
            _elements.GetStartedButton.Click();
        }

        public void EnterTarget(string text)
        {
            _elements.TargetInput.SendKeys(text);
            _elements.TargetInput.SendKeys(Keys.Enter);
        }

        public void EnterProblem(string text)
        {
            _elements.ProblemInput.SendKeys(text);
            _elements.ProblemInput.SendKeys(Keys.Enter);
        }

        public void EnterDislike(string text)
        {
            _elements.DislikeInput.SendKeys(text);
            _elements.DislikeInput.SendKeys(Keys.Enter);
        }

        public void EnterUniqueSolution(string text)
        {
            _elements.UniqueSolutionInput.SendKeys(text);
            _elements.UniqueSolutionInput.SendKeys(Keys.Enter);
        }

        public void EnterHowUniqueWork(string text)
        {
            _elements.HowUniqueWorkInput.SendKeys(text);
            _elements.HowUniqueWorkInput.SendKeys(Keys.Enter);
        }

        public void EnterResearch(string text)
        {
            _elements.ResearchInput.SendKeys(text);
            _elements.ResearchInput.SendKeys(Keys.Enter);
        }

        public void EnterTestimonials(string text)
        {
            _elements.TestimonialsInput.SendKeys(text);
            _elements.TestimonialsInput.SendKeys(Keys.Enter);
        }

        public void SelectRole(string text)
        {
            SelectElement select = new SelectElement(_elements.RoleDropdown);
            select.SelectByText(text);
        }

        public void ClickGetAd()
        {
            _elements.GetAdButton.Click();
        }

        public void VerifyLanguage(string language)
        {
            Dictionary<string, string> h1 = new Dictionary<string, string>()
            {
                { "en", "$1B Copywriter Creates FREE AI Copy Generator That Will Beat Your" },
                { "es", "Copywriter de mil millones de dólares crea un generador de IA para copias GRATUITO que superará tus anuncios" },
                { "fr", "1 milliard de dollars Copywriter crée un générateur de copie IA GRATUIT qui battra vos publicités" },
                { "de", "1-Milliarden-Dollar-Copywriter erstellt KOSTENLOSE KI-Textgeneratoren, die Ihre schlagen werden" },
                { "it", "Copywriter da 1 miliardo di dollari crea un generatore di copy AI GRATUITO che batterà il tuo" },
                { "pt", "Copywriter de bilhões de dólares cria um gerador de IA para cópias GRATUITO que superará seus anúncios" },
                { "idn", "$1B Penulis Iklan Membuat Generator AI Copy GRATIS yang Akan Mengalahkan" },
                { "ru", "$1 млрд. копирайтер создает БЕСПЛАТНОГО генератора текстов AI, который побьет ваши" },
                { "pol", "Copywriter wart 1 miliarda dolarów tworzy DARMOWY generator AI Copy, który pokona Twoje" },
                { "uk", "Копірайтер на $1 мільярд створює БЕЗКОШТОВНИЙ генератор тексту AI, який перевершить ваш" }
            };
            _wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("h1")));
            //Assert.AreEqual(h1[language], _driver.FindElement(By.TagName("h1")).Text);
            Assert.That(h1[language], Is.EqualTo(_driver.FindElement(By.TagName("h1")).Text));
        }

        public void ClickTemplateOption()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".flex-1 > a:nth-child(3)")));
            _elements.TemplateOption.Click();
        }

        public void SelectEmailTemplate()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(":nth-child(1) > .rotating-card-container")));
            Assert.That(_driver.FindElement(By.CssSelector(":nth-child(1) > .rotating-card-container")).Displayed, Is.True);
            //_elements.EmailTemplateOption.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", _elements.EmailTemplateOption);

        }

        public void FillTheFields()
        {
            // You need to add the correct logic to fill the fields
            // Example:
            EnterTarget("Test Target");
            EnterProblem("Test Problem");
            // Add more fields as needed
        }

        public void ClickGenerateAdButton()
        {
            _elements.GenerateAdButton.Click();
        }

        public void VerifyAd()
        {
            // You need to add the correct logic to verify the ad
            // Example:
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ad-container"))); // Assuming there's a container for the generated ad
            //Assert.IsTrue(_driver.FindElement(By.CssSelector(".ad-container")).Displayed);
            Assert.That(_driver.FindElement(By.CssSelector(".ad-container")).Displayed,Is.True);
        }

        public void ClickMyAdsOption()
        {
            _elements.MyAdsOption.Click();
        }
    }
}
