using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class WhoIsResposibleToMaintainExpectationsPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us who's responsible for maintaining these expectations for quality and high standards in apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By LabelCssSelector => By.CssSelector(".govuk-form-group");

        public WhoIsResposibleToMaintainExpectationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowAreTheyCommunicatedToEmployeesPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", applydataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", applydataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", applydataHelpers.ContactNumber);
            Continue();
            return new HowAreTheyCommunicatedToEmployeesPage(_context);
        }

    }
}


