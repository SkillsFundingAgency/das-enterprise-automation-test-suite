using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class DescribeYourOrganisationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How would you describe your organisation?";
        protected override By PageHeader => By.CssSelector("h2.govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By PublicServiceMutualRadio => By.CssSelector("input[type='checkbox'][value='A public service mutual']");
        private By ShelteredWorkshopRadio => By.CssSelector("input[type='checkbox'][value='A sheltered workshop']");

        public DescribeYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PublicServiceMutualRadio));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ShelteredWorkshopRadio));
            Continue();
            return new ApplicationOverviewPage(_context);
        }
        public ApplicationOverviewPage ClickContinueForDescribeYourOrgDetailsSelected()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
