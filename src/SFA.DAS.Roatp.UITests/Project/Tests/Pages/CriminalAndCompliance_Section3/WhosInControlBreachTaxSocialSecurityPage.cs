using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlBreachTaxSocialSecurityPage : RoatpBasePage
    {
        protected override string PageTitle => "breached tax payments or social security contributions in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlBreachTaxSocialSecurityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IsAnyOneControlOfRemovedTrusteePage SelectYesEnterInformationForBreachingTaxandSocialSecurityContributionsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlBreachTaxSocialSecurity);
            return new IsAnyOneControlOfRemovedTrusteePage(_context);
        }
    }
}
