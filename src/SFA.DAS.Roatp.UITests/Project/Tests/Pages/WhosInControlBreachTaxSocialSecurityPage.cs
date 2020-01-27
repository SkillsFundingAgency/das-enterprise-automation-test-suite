using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
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

        public WhosInControlBankruptInLastThreeYearsPage SelectYesEnterInformationForBreachingTaxandSocialSecurityContributionsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlBreachTaxSocialSecurityOrganisations) ? LongTextArea_WhosInControlBreachTaxSocialSecurityOrganisations : LongTextArea_WhosInControlBreachTaxSocialSecuritySoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlBreachTaxSocialSecurity);
            Continue();
            return new WhosInControlBankruptInLastThreeYearsPage(_context);
        }
    }

    public class WhosInControlBankruptInLastThreeYearsPage : RoatpBasePage
    {
        protected override string PageTitle => "partner organisations been made bankrupt in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlBankruptInLastThreeYearsOrganisations => By.Id("CC-110.1");
        private By LongTextArea_WhosInControlBankruptInLastThreeYearsSoleTrader => By.Id("CC-111.1");

        public WhosInControlBankruptInLastThreeYearsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesEnterInformationForBankruptAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlBankruptInLastThreeYearsOrganisations) ? LongTextArea_WhosInControlBankruptInLastThreeYearsOrganisations : LongTextArea_WhosInControlBankruptInLastThreeYearsSoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlBankruptInLastThreeYears);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
