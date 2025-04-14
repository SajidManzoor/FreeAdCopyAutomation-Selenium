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

        public By TemplateTab =>By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(3)");
        public By FavoritesOption =>By.CssSelector(".flex-1 > :nth-child(10) > :nth-child(3)");
        public By MyAdsOption =>By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(7)");
        public By TemplateCategory =>By.CssSelector(".mt-8 > div:nth-child(2)");
        public By TemplateFb =>By.CssSelector(".mt-5 > .grid > div:nth-child(2)");
        public By AdContent =>By.CssSelector("#ads > :nth-child(3)"); 
        public By AdSelect =>By.CssSelector(".rt-TableBody > tr:nth-child(2)");
        public By EditIcon =>By.CssSelector("[src='/icons/dashboard/adsResult/light/edit.svg']");
        public By SaveBtn =>By.CssSelector(".flex > .border:nth-child(3)");
        public By ProfileIcon =>By.CssSelector(".flex > .flex > .w-11");
        public By SettingsTab =>By.CssSelector("ul > :nth-child(2)");
        public By ReportBugTab =>By.CssSelector("ul > :nth-child(4)");
        public By SignoutTab =>By.CssSelector(".space-y-3 > li:nth-child(5)");
        public By ReportBug =>By.Id("message");
        public By ReportSubmitBtn =>By.CssSelector(".py-3");
        public By LearningTab =>By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(9)");
        public By FreeVideo =>By.CssSelector(".pb-20 > .mt-5:nth-child(3) > .w-full > .relative:nth-child(1)");
        public By PlayVideo =>By.CssSelector(".h-[40vh] > [data-media-provider=''] > video");
        public By SearchBar =>By.CssSelector(".ml-5 > .relative > .bg-gray-50");
        public By SearchField =>By.Id("simple-search");
        public By PurchasesTab =>By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(9)");
        public By EmailCategory => By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By EmailSequence => By.CssSelector(":nth-child(4) > :nth-child(1) > .rotating-card-container");
        public By EmailTemplate =>By.CssSelector(":nth-child(1) > .rotating-card-container");
        public By TemplateElement =>By.CssSelector("#template > .grid > .block > .rotating-card-container > .p-5 > .px-4 > .text-xl");
        public By YoutubeCategory =>By.XPath("//div[@class='grid'][contains(.,'YouTube Ads')]"); 
        public By BredcrumbYoutube =>By.XPath("//div[@class='text-md'][contains(.,'youtube ads')]");
        public By YoutubeTemplate =>By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By MarketResCategory =>By.CssSelector(".grid > .mt-4:nth-child(4)");
        public By BredcrumbMarketRes =>By.XPath("//div[@class='text-md'][contains(.,'market research')]");
        public By MarketTemplate =>By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By MiscCategory =>By.XPath("//div[@class='pb-7']/div[5]/div[@class='back'][contains(.,'Misc')]");
        public By BredcrumbMisc =>By.XPath("//div[@class='text-md'][contains(.,'misc')]");
        public By MiscTemplate =>By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By AdvertorialCategory =>By.XPath("//div[@class='rotating-card-container'][contains(.,'Advertorial')]");
        public By BredcrumbAdvert =>By.XPath("//div[@class='text-md'][contains(.,'advertorial ads')]");
        public By AdvertorialTemplate =>By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By GreetingsText =>By.CssSelector(".p-4 > .text-2xl");
        public By FirstTemplate =>By.CssSelector("#template > .grid > :nth-child(1) > .rotating-card-container");
        public By NewestTemplate =>By.CssSelector("#template > .grid > :nth-child(1)");
        public By CreditsText =>By.CssSelector(".flex-1 > :nth-child(5)");
        public By BuyCreditsBtn =>By.CssSelector(".flex-end > .text-white");
        public By NewestTemplateElement =>By.CssSelector("#template > .grid .rotating-card-container");
        public IReadOnlyCollection<IWebElement> NewestTemplates => _driver.FindElements(By.CssSelector("#template > .grid > .rotating-card-container")); 

    }
}
