using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class IsAnyOneControlOfRemovedTrusteePage : RoatpBasePage
    {
        protected override string PageTitle => "Register of Removed Trustees?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public IsAnyOneControlOfRemovedTrusteePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlBankruptInLastThreeYearsPage SelectNo()
        {
            SelectNoAndContinue();
            return new WhosInControlBankruptInLastThreeYearsPage(_context);
        }
    }


    public class WhosInControlBreachTaxSocialSecurityPage : RoatpBasePage
    {
        protected override string PageTitle => "breached tax payments or social security contributions in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlBreachTaxSocialSecurityOrganisations => By.Id("CC-100.1");

        private By LongTextArea_WhosInControlBreachTaxSocialSecuritySoleTrader => By.Id("CC-101.1");

        public WhosInControlBreachTaxSocialSecurityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IsAnyOneControlOfRemovedTrusteePage SelectYesEnterInformationForBreachingTaxandSocialSecurityContributionsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlBreachTaxSocialSecurityOrganisations) ? LongTextArea_WhosInControlBreachTaxSocialSecurityOrganisations : LongTextArea_WhosInControlBreachTaxSocialSecuritySoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlBreachTaxSocialSecurity);
            Continue();
            return new IsAnyOneControlOfRemovedTrusteePage(_context);
        }
    }
}
