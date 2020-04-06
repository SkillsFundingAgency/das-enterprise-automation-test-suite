using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class ContractTerminatedByPublicBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had a contract terminated early by a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ContractTerminatedByPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WithdrawnFromAContractWithPublicBodyPage SelectYesAndEnterInformationForContractTerminatedByPublicBodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.ContractTerminatedByPublicBody);
            return new WithdrawnFromAContractWithPublicBodyPage(_context);
        }
    }
}