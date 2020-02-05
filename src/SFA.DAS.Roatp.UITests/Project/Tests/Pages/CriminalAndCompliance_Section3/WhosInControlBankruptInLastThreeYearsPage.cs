using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
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
