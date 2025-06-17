using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WebsitePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have a website?";

        private static By MainWebsiteField => By.Id("YO-41");

        public WebsitePage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EneterWebsiteAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-40");
            formCompletionHelper.EnterText(MainWebsiteField, applydataHelpers.Website);
            Continue();
            return new ApplicationOverviewPage(context);
        }

        public ApplicationOverviewPage ClickContinueForWebsiteEntered()
        {
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
