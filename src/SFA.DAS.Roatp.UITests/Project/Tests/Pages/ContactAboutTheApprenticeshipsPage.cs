using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ContactAboutTheApprenticeshipsPage : RoatpBasePage
    {
        protected override string PageTitle => "Who can we contact about the apprenticeships your organisation will deliver?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullNameTextBox => By.Id("PAT-671");

        private By EmailTextBox => By.Id("PAT-672");

        public ContactAboutTheApprenticeshipsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterContactDetailsAndContinue()
        {
            formCompletionHelper.EnterText(FullNameTextBox, applydataHelpers.FullName);
            formCompletionHelper.EnterText(EmailTextBox, applydataHelpers.Email);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
