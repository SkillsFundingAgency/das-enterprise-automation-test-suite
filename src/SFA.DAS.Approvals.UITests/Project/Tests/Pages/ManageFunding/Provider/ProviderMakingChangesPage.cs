using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderMakingChangesPage : ReservationIdBasePage
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
		private By GoToRadioButton => By.CssSelector(".govuk-radios__label");

		#region Helpers and Context
		private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderMakingChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        internal ApprovalsProviderHomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToRadioButton, "WhatsNext-home");
            Continue();
            return new ApprovalsProviderHomePage(_context);
        }

        internal ProviderAddApprenticeDetailsPage GoToAddApprenticeDetailsPage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToRadioButton, "WhatsNext-add");
            Continue();
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        public new ProviderMakingChangesPage VerifySucessMessage()
        {
            base.VerifySucessMessage();
            return this;
        }
    }
}
