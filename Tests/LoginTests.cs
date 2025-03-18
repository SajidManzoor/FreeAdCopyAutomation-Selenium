//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using ConsoleApp3.Pages;
//using WebDriverManager;
//using WebDriverManager.DriverConfigs.Impl;


//namespace ConsoleApp3.Tests
//{
//    [TestFixture]
//    class LoginTests
//    {
//        private IWebDriver driver;
//        private LoginPage loginPage;

//        [SetUp]
//        public void Setup()
//        {
//            new DriverManager().SetUpDriver(new ChromeConfig());
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1");

//            loginPage = new LoginPage(driver);

//            //ChromeOptions options = new ChromeOptions();
//            //driver = new ChromeDriver(options);
//            //driver.Navigate().GoToUrl("https://www.saucedemo.com/v1");
//        }

//        [Test]
//        public void Test_ValidLogin()
//        {
//            loginPage.EnterUsername("standard_user");
//            loginPage.EnterPassword("secret_sauce");
//            loginPage.ClickLogin();

//            Assert.That(driver.Url.Contains("inventory"),Is.True,"Login Failed");
//        }
//        [Test]
//        public void Test_InvalidLogin()
//        {
//            loginPage.EnterUsername("wrongUser");
//            loginPage.EnterPassword("wrongPass");
//            loginPage.ClickLogin();

//            //Assert.That(loginPage.GetErrorMessage(),Is.EqualTo("Invalid username or password"),"Error message mismatch");

//        }
//        [TearDown]
//        public void Cleanup()
//        {
//            driver.Quit();
//        }

//    }
//}
