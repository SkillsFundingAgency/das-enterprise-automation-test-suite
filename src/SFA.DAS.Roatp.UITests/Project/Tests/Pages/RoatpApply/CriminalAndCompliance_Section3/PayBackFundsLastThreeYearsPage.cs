using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class PayBackFundsLastThreeYearsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation failed to pay back funds in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PayBackFundsLastThreeYearsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContractTerminatedByPublicBodyPage SelectYesEnterInformationForFailedToPayFundsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.PayBackFundsLastThreeYears);
            return new ContractTerminatedByPublicBodyPage(_context);
        }
    }
}
