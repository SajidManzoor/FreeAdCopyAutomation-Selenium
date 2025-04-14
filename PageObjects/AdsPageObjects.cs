using OpenQA.Selenium;

public class AdsPageObjects
{
    private IWebDriver driver;

    public AdsPageObjects(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Locator for the Target Market input field
    public By TargetMarketField => By.CssSelector(".relative > #target");

    // Locator for the Pain Point input field
    public By PainPointField => By.CssSelector(".relative > #problem");

    // Locator for the Dislike Solution input field
    public By DislikeSolField => By.CssSelector(".relative > #dislike");

    // Locator for the Unique Solution input field
    public By UniqueSolField => By.CssSelector(".relative > #uniqueSolution");

    // Locator for the Language dropdown menu
    public By LanguageDropdown => By.CssSelector(".rt-reset");

    // Locator for the Generate button
    public By GenerateButton => By.CssSelector(".gap-3 > .flex > #generate");
}
