using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlContractTerminatedByPublicBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "had a contract terminated by a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlContractTerminatedByPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlContractWithdrawnWithPublicBodyPage SelectYesEnterInformationForContractTerminatedByPublicBodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlContractTerminatedByPublicBody);
            return new WhosInControlContractWithdrawnWithPublicBodyPage(_context);
        }
    }
}
