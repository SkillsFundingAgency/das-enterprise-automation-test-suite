using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class DescribeYourOrganisationPage : RoatpBasePage
    {
        protected override string PageTitle => "How would you describe your organisation?";
        protected override By PageHeader => By.TagName("h2");

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
            formCompletionHelper.ClickElement(PublicServiceMutualRadio);
            formCompletionHelper.ClickElement(ShelteredWorkshopRadio);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
