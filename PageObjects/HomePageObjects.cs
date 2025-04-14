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

        public By LoginNavbar =>By.CssSelector(".-top-50 > .text-\\[16px\\]");
        public By SignupButton =>By.CssSelector("a[href='/signup']");
        public By GetStartedNav =>By.CssSelector("a[href='/templates']");
        public By GetStartedButton =>By.CssSelector("a[href='/templates']");
        public By TargetInput =>By.Id("target_input_id");
        public By ProblemInput =>By.Id("problem_input_id");
        public By DislikeInput =>By.Id("dislike_input_id");
        public By UniqueSolutionInput =>By.Id("unique_solution_input_id");
        public By HowUniqueWorkInput =>By.Id("how_unique_work_input_id");
        public By ResearchInput =>By.Id("research_input_id");
        public By TestimonialsInput =>By.Id("testimonials_input_id");
        public By RoleDropdown =>By.Id("role_dropdown_id");
        public By GetAdButton =>By.Id("get_ad_button_id");
        public By TemplateOption =>By.CssSelector(".space-y-4 > .flex-1 > a:nth-child(3)");
        public By EmailTemplateOption =>By.CssSelector(".grid > .mt-4:nth-child(1)");
        public By GenerateAdButton =>By.Id("generate_ad_button_id");
        public By MyAdsOption =>By.CssSelector("a[href='/my-ads']");
    }
}
