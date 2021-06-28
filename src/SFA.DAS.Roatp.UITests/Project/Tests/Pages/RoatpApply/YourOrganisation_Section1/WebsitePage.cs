using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WebsitePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have a website?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MainWebsiteField => By.Id("YO-41");

        public WebsitePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EneterWebsiteAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-40");
            formCompletionHelper.EnterText(MainWebsiteField, applydataHelpers.Website);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
        public ApplicationOverviewPage ClickContinueForWebsiteEntered()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
