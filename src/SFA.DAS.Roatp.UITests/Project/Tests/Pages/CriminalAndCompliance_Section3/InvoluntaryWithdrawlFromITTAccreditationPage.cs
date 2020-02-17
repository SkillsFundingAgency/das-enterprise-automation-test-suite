using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class InvoluntaryWithdrawlFromITTAccreditationPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation had involuntary withdrawal from Initial Teacher Training accreditation in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvoluntaryWithdrawlFromITTAccreditationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RemovedFromCharityRegisterPage SelectYesEnterInformationForWithdrawlfromITTAccreditationAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InvoluntaryWithdrawlFromITTAccreditation);
            return new RemovedFromCharityRegisterPage(_context);
        }
    }
}