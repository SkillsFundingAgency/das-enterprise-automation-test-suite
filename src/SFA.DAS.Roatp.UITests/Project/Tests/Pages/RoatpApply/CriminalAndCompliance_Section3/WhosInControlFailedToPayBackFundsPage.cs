using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlFailedToPayBackFundsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "failed to pay back funds in the last 3 years?";

        public WhosInControlFailedToPayBackFundsPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhosInControlInvestigatedForFraudOrIrregularitiesPage SelectYesEnterInformationForFailedToPayBackFundAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlFailedToPayBackFunds);
            return new WhosInControlInvestigatedForFraudOrIrregularitiesPage(_context);
        }
    }
}
