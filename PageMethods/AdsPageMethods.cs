using FreeAdCopyAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; //For SelectElement
using SeleniumExtras.WaitHelpers;

public class AdsPageMethods
{
    private IWebDriver _driver;
    private AdsPageObjects adsElements;
    private LoginObjects loginElements; 
    private readonly WebDriverWait _wait;

    public AdsPageMethods(IWebDriver driver)
    {
        _driver = driver;
        this.adsElements = new AdsPageObjects(driver);
        this.loginElements = new LoginObjects(driver); // Initialize LoginPageElements
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void FillAdsForm(string targetMarket, string painPoint, string dislikeSol, string uniqueSol)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".relative > #target"))); // Wait for the element to be visible
        adsElements.TargetMarketField.SendKeys(targetMarket);
        adsElements.PainPointField.SendKeys(painPoint);
        adsElements.DislikeSolField.SendKeys(dislikeSol);
        adsElements.UniqueSolField.SendKeys(uniqueSol);
    }

    public void FillAdsFormMarketRes(string targetMarket, string uniqueSol)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".relative > #target"))); // Wait for the element to be visible
        adsElements.TargetMarketField.SendKeys(targetMarket);
        adsElements.UniqueSolField.SendKeys(uniqueSol);
        //_driver.FindElement(By.CssSelector(".rt-reset")).Click(); //Might need adjustment
        //adsElements.SelectLanguage("en");
    }

    public void EnterData(string data)
    {
        adsElements.TargetMarketField.SendKeys(data);
    }

    public void ClickGenerateAdBtn()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].click();", adsElements.GenerateButton);
    }

    public void VerifyNotify(string toastMessage)
    {
        //This will depend heavily on how the toast message is implemented in your application.  This is a placeholder.
        IWebElement toast = loginElements.Toast; // Assuming loginElements has a Toast property
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Add a wait
        wait.Until(ExpectedConditions.ElementToBeClickable(toast)); // Wait for the element to be clickable
        Assert.That(toast.Text, Is.EqualTo(toastMessage)); //Use a testing framework like NUnit or MSTest for assertions.
    }
}
