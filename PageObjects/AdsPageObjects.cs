using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class AdsPageObjects
{
    private IWebDriver driver;

    public AdsPageObjects(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IWebElement TargetMarketField => driver.FindElement(By.CssSelector(".relative > #target"));
    public IWebElement PainPointField => driver.FindElement(By.CssSelector(".relative > #problem"));
    public IWebElement DislikeSolField => driver.FindElement(By.CssSelector(".relative > #dislike"));
    public IWebElement UniqueSolField => driver.FindElement(By.CssSelector(".relative > #uniqueSolution"));
    public IWebElement LanguageDropdown => driver.FindElement(By.CssSelector(".rt-reset")); //This might need adjustment.  .rt-reset is likely a class, not a unique identifier.  Consider using a more specific selector.
    public IWebElement GenerateButton => driver.FindElement(By.CssSelector(".gap-3 > .flex > #generate"));

}
