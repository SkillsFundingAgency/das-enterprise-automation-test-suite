using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhosInControlInvestigatedForFraudOrIrregularitiesPage : RoatpBasePage
    {
        protected override string PageTitle => "investigated for fraud or irregularities in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlInvestigatedForFraudorIrregularitiesOrganisations => By.Id("CC-60.1");
        private By LongTextArea_WhosInControlInvestigatedForFraudorIrregularitiesSoleTrader => By.Id("CC-61.1");

        public WhosInControlInvestigatedForFraudOrIrregularitiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlOngoingInvestigationsForFraudPage SelectYesEnterInformationForFraudOrIrregularities()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlInvestigatedForFraudorIrregularitiesOrganisations) ? LongTextArea_WhosInControlInvestigatedForFraudorIrregularitiesOrganisations : LongTextArea_WhosInControlInvestigatedForFraudorIrregularitiesSoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlInvestigatedForFraudorIrregularities);
            Continue();
            return new WhosInControlOngoingInvestigationsForFraudPage(_context);
        }
    }
}
