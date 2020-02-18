using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlInvestigatedForFraudOrIrregularitiesPage : RoatpBasePage
    {
        protected override string PageTitle => "investigated for fraud or irregularities in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlInvestigatedForFraudOrIrregularitiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlOngoingInvestigationsForFraudPage SelectYesEnterInformationForFraudOrIrregularities()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlInvestigatedForFraudorIrregularities);
            return new WhosInControlOngoingInvestigationsForFraudPage(_context);
        }
    }
}
