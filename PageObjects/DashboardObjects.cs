using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FreeAdCopyAutomation.PageObjects
{
    public class DashBoardObjects
    {
        private readonly IWebDriver _driver;

        public DashBoardObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement TemplateTab => _driver.FindElement(By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(3)"));
        public IWebElement FavoritesOption => _driver.FindElement(By.CssSelector(".flex-1 > :nth-child(10) > :nth-child(3)"));
        public IWebElement MyAdsOption => _driver.FindElement(By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(7)"));
        public IWebElement TemplateCategory => _driver.FindElement(By.CssSelector(".mt-8 > div:nth-child(2)"));
        public IWebElement TemplateFb => _driver.FindElement(By.CssSelector(".mt-5 > .grid > div:nth-child(2)"));
        public IWebElement AdContent => _driver.FindElement(By.CssSelector("#ads > :nth-child(3)")); //This might need adjustment
        public IWebElement AdSelect => _driver.FindElement(By.CssSelector(".rt-TableBody > tr:nth-child(2)"));
        public IWebElement EditIcon => _driver.FindElement(By.CssSelector("[src='/icons/dashboard/adsResult/light/edit.svg']"));
        public IWebElement SaveBtn => _driver.FindElement(By.CssSelector(".flex > .border:nth-child(3)"));
        public IWebElement ProfileIcon => _driver.FindElement(By.CssSelector(".flex > .flex > .w-11"));
        public IWebElement SettingsTab => _driver.FindElement(By.CssSelector(".space-y-3 > li:nth-child(2)"));
        public IWebElement ReportBugTab => _driver.FindElement(By.CssSelector("ul > :nth-child(4)"));
        public IWebElement SignoutTab => _driver.FindElement(By.CssSelector(".space-y-3 > li:nth-child(5)"));
        public IWebElement ReportBug => _driver.FindElement(By.Id("message"));
        public IWebElement ReportSubmitBtn => _driver.FindElement(By.CssSelector(".py-3"));
        public IWebElement LearningTab => _driver.FindElement(By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(9)"));
        public IWebElement FreeVideo => _driver.FindElement(By.CssSelector(".pb-20 > .mt-5:nth-child(3) > .w-full > .relative:nth-child(1)"));
        public IWebElement PlayVideo => _driver.FindElement(By.CssSelector(".h-[40vh] > [data-media-provider=''] > video"));
        public IWebElement SearchBar => _driver.FindElement(By.CssSelector(".ml-5 > .relative > .bg-gray-50"));
        public IWebElement SearchField => _driver.FindElement(By.Id("simple-search"));
        public IWebElement PurchasesTab => _driver.FindElement(By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(9)"));
        public IWebElement EmailCategory => _driver.FindElement(By.XPath("//div[@class='grid']/div[@class='mt-4'][1]")).FindElement(By.XPath(".//span[text()='Email Copy']")); // More robust XPath
        public IWebElement EmailSequence => _driver.FindElement(By.CssSelector(":nth-child(4) > :nth-child(1) > .rotating-card-container"));
        public IWebElement EmailTemplate => _driver.FindElement(By.CssSelector(":nth-child(1) > .rotating-card-container"));
        public IWebElement TemplateElement => _driver.FindElement(By.CssSelector("#template > .grid > .block > .rotating-card-container > .p-5 > .px-4 > .text-xl"));
        public IWebElement YoutubeCategory => _driver.FindElement(By.XPath("//div[@class='grid'][contains(.,'YouTube Ads')]")); //XPath for better handling
        public IWebElement BredcrumbYoutube => _driver.FindElement(By.XPath("//div[@class='text-md'][contains(.,'youtube ads')]"));
        public IWebElement YoutubeTemplate => _driver.FindElement(By.CssSelector(".grid > .mt-4:nth-child(1)"));
        public IWebElement MarketResCategory => _driver.FindElement(By.XPath("//div[@class='pb-7']/div[4]/div[@class='back'][contains(.,'Market Research')]"));
        public IWebElement BredcrumbMarketRes => _driver.FindElement(By.XPath("//div[@class='text-md'][contains(.,'market research')]"));
        public IWebElement MarketTemplate => _driver.FindElement(By.CssSelector(".grid > .mt-4:nth-child(1)"));
        public IWebElement MiscCategory => _driver.FindElement(By.XPath("//div[@class='pb-7']/div[5]/div[@class='back'][contains(.,'Misc')]"));
        public IWebElement BredcrumbMisc => _driver.FindElement(By.XPath("//div[@class='text-md'][contains(.,'misc')]"));
        public IWebElement MiscTemplate => _driver.FindElement(By.CssSelector(".grid > .mt-4:nth-child(1)"));
        public IWebElement AdvertorialCategory => _driver.FindElement(By.XPath("//div[@class='rotating-card-container'][contains(.,'Advertorial')]"));
        public IWebElement BredcrumbAdvert => _driver.FindElement(By.XPath("//div[@class='text-md'][contains(.,'advertorial ads')]"));
        public IWebElement AdvertorialTemplate => _driver.FindElement(By.CssSelector(".grid > .mt-4:nth-child(1)"));
        public IWebElement GreetingsText => _driver.FindElement(By.CssSelector(".p-4 > .text-2xl"));
        public IWebElement FirstTemplate => _driver.FindElement(By.CssSelector("#template > .grid > :nth-child(1) > .rotating-card-container"));
        public IWebElement NewestTemplate => _driver.FindElement(By.CssSelector("#template > .grid > :nth-child(1)"));
        public IWebElement CreditsText => _driver.FindElement(By.CssSelector(".flex-1 > :nth-child(5)"));
        public IWebElement BuyCreditsBtn => _driver.FindElement(By.CssSelector(".flex-end > .text-white"));
        public IWebElement NewestTemplateElement => _driver.FindElement(By.CssSelector("#template > .grid .rotating-card-container"));
        public IReadOnlyCollection<IWebElement> NewestTemplates => _driver.FindElements(By.CssSelector("#template > .grid > .rotating-card-container")); // Returns a collection

    }
}
