using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class EnterWebsiteLinkPage : RoatpBasePage
    {
        protected override string PageTitle => "Enter the website link for your organisation's complaints policy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        private By WebsiteField => By.Id("RTE-31");

        public EnterWebsiteLinkPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage EnterWebsitelinkandContinue()
        {
            formCompletionHelper.EnterText(WebsiteField, applydataHelpers.Website);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
