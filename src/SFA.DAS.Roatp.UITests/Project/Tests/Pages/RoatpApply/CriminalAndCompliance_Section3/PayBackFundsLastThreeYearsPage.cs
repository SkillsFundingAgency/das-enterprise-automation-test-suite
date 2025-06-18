using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class PayBackFundsLastThreeYearsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation failed to pay back funds in the last 3 years?";

        #region Helpers and Context

        #endregion

        public PayBackFundsLastThreeYearsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ContractTerminatedByPublicBodyPage SelectYesEnterInformationForFailedToPayFundsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.PayBackFundsLastThreeYears);
            return new ContractTerminatedByPublicBodyPage(context);
        }
    }
}
