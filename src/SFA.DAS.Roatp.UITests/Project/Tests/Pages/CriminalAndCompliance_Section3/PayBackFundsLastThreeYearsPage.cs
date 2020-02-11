using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class PayBackFundsLastThreeYearsPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation failed to pay back funds in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_PayBackFundsLastThreeYears => By.Id("CC-21.1");

        public PayBackFundsLastThreeYearsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContractTerminatedByPublicBodyPage SelectYesEnterInformationForFailedToPayFundsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_PayBackFundsLastThreeYears, applydataHelpers.PayBackFundsLastThreeYears);
            Continue();
            return new ContractTerminatedByPublicBodyPage(_context);
        }
    }
}
