using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ResultsFoundPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"found for '{objectContext.GetProviderName()}'";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OnBoardingStatus => By.XPath("//span[text()='On-boarding']");

        private By ActiveStatus => By.XPath("//span[text()='Active']");

        private string MainAndEmployerStatus => "ON-BOARDING";

        private string SupportingStatus => "ACTIVE";

        public ResultsFoundPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public bool VerifyMainAndEmployerTypeStatus() => pageInteractionHelper.VerifyText(OnBoardingStatus, MainAndEmployerStatus);

        public bool VerifySupportingProviderTypeStatus() => pageInteractionHelper.VerifyText(ActiveStatus, SupportingStatus);
    }
}
