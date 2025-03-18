using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FreeAdCopyAutomation.PageObjects
{
    class HomePageObjects
    {
        private readonly IWebDriver _driver;

        public HomePageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginNavbar => _driver.FindElement(By.CssSelector(".-top-50 > .text-\\[16px\\]")); // Assuming this is the selector for the login link
        public IWebElement SignupButton => _driver.FindElement(By.CssSelector("a[href='/signup']")); // Assuming this is the selector for the signup button
        public IWebElement GetStartedNav => _driver.FindElement(By.CssSelector("a[href='/templates']")); // Assuming this is the selector for the get started link
        public IWebElement GetStartedButton => _driver.FindElement(By.CssSelector("a[href='/templates']")); // Assuming this is the selector for the get started button
        public IWebElement TargetInput => _driver.FindElement(By.Id("target_input_id")); // You need to find the correct id
        public IWebElement ProblemInput => _driver.FindElement(By.Id("problem_input_id")); // You need to find the correct id
        public IWebElement DislikeInput => _driver.FindElement(By.Id("dislike_input_id")); // You need to find the correct id
        public IWebElement UniqueSolutionInput => _driver.FindElement(By.Id("unique_solution_input_id")); // You need to find the correct id
        public IWebElement HowUniqueWorkInput => _driver.FindElement(By.Id("how_unique_work_input_id")); // You need to find the correct id
        public IWebElement ResearchInput => _driver.FindElement(By.Id("research_input_id")); // You need to find the correct id
        public IWebElement TestimonialsInput => _driver.FindElement(By.Id("testimonials_input_id")); // You need to find the correct id
        public IWebElement RoleDropdown => _driver.FindElement(By.Id("role_dropdown_id")); // You need to find the correct id
        public IWebElement GetAdButton => _driver.FindElement(By.Id("get_ad_button_id")); // You need to find the correct id
        //public IWebElement TemplateOption => _driver.FindElement(By.CssSelector(".flex-1 > a:nth-child(3)")); // Assuming this is the selector for the template option in the sidebar
        public IWebElement TemplateOption => _driver.FindElement(By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(3)"));
        //public IWebElement EmailTemplateOption => _driver.FindElement(By.CssSelector("a[href='/templates/email']")); // You need to find the correct selector
        public IWebElement EmailTemplateOption=>_driver.FindElement(By.CssSelector(":nth-child(1) > .rotating-card-container"));
        public IWebElement GenerateAdButton => _driver.FindElement(By.Id("generate_ad_button_id")); // You need to find the correct id
        public IWebElement MyAdsOption => _driver.FindElement(By.CssSelector("a[href='/my-ads']")); // You need to find the correct selector
    }
}
