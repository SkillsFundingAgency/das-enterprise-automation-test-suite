using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class DescribeYourOrganisationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How would you describe your organisation?";
         
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

        public TradingPeriodPage SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PublicServiceMutualRadio));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ShelteredWorkshopRadio));
            Continue();
            return new TradingPeriodPage(_context);
        }
        public TradingPeriodPage ClickContinueForDescribeYourOrgDetailsSelected()
        {
            Continue();
            return new TradingPeriodPage(_context);
        }
    }
}
