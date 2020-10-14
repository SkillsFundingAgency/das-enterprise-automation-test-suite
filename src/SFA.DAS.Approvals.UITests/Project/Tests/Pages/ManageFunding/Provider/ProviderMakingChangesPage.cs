using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderMakingChangesPage : ReservationIdBasePage
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
		
		#region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ContinueButtonTo = By.XPath("//button[contains(text(),'Continue')]");

        public ProviderMakingChangesPage(ScenarioContext context) : base(context) => _context = context;

        internal ApprovalsProviderHomePage GoToHomePage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-home");
            formCompletionHelper.ClickElement(ContinueButtonTo);
            return new ApprovalsProviderHomePage(_context);
        }

        internal ProviderAddApprenticeDetailsPage GoToAddApprenticeDetailsPage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-add");
            formCompletionHelper.ClickElement(ContinueButtonTo);
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        public new ProviderMakingChangesPage VerifySucessMessage()
        {
            base.VerifySucessMessage();
            return this;
        }
    }
}
