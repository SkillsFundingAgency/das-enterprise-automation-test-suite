using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public abstract class ApprenticeshipTrainingCourseBasePage : FATV2BasePage
    {
        protected override string PageTitle => "Apprenticeship training courses";
        private readonly IWebDriver _webDriver;

        protected override bool TakeFullScreenShot => false;

        public ApprenticeshipTrainingCourseBasePage(ScenarioContext context) : base(context) 
        {
            _webDriver = context.GetWebDriver();
            var environmentName = Configurator.EnvironmentName.ToLower() + "-";
            var currentURL = GetUrl();

            if (!currentURL.ToLower().Contains(environmentName))
            {
                var newURL = currentURL.Insert(8, environmentName);
                _webDriver.Navigate().GoToUrl(newURL);                
            }
        }
    }
}
