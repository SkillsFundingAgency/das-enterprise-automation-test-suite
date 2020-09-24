using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SettingUpAServicenPage : ApprenticeBasePage
    {

        protected override string PageTitle => "Page not found";
        private By FaaHeaderPage => By.CssSelector(".heading-xlarge");
        public SettingUpAServicenPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(FaaHeaderPage, PageTitle);
        }
    }
}