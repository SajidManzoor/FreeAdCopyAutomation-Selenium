using FreeAdCopyAutomation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class AdsPageMethods
{
    private IWebDriver _driver;
    private AdsPageObjects adsElements;
    private readonly WebDriverWait _wait;
    private readonly Utilities _utils;
    public AdsPageMethods(IWebDriver driver)
    {
        _driver = driver;
        this.adsElements = new AdsPageObjects(driver);
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        _utils = new Utilities(driver);
    }

    public void FillAdsForm(string targetMarket, string painPoint, string dislikeSol, string uniqueSol)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(adsElements.TargetMarketField));
        //Assert.That(_driver.Url, Does.Contain("/ads"), "URL does not contain '/ads'");
        _utils.EnterText(adsElements.TargetMarketField, targetMarket);
        _utils.EnterText(adsElements.PainPointField, painPoint);
        _utils.EnterText(adsElements.DislikeSolField, dislikeSol);
        _utils.EnterText(adsElements.UniqueSolField, uniqueSol);
    }

    public void FillAdsFormMarketRes(string targetMarket, string uniqueSol)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(adsElements.TargetMarketField));
        _utils.EnterText(adsElements.TargetMarketField, targetMarket);
        _utils.EnterText(adsElements.UniqueSolField, uniqueSol);
    }

    public void ClickGenerateAdBtn()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].click();", adsElements.GenerateButton);
    }
}
