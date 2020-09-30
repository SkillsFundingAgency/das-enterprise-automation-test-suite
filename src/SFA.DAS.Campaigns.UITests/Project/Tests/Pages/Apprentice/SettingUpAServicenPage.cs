using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SettingUpAServicenPage : ApprenticeBasePage
    {

        protected override string PageTitle => "Set up a service account";
        private By FaaHeaderPage => By.CssSelector(".heading-xlarge");
        public SettingUpAServicenPage(ScenarioContext context) : base(context) { }
    }
}