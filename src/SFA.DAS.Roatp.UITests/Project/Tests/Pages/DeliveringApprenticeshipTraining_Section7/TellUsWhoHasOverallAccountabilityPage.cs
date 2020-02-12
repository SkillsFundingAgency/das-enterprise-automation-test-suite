using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class TellUsWhoHasOverallAccountabilityPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us who has overall accountability for apprenticeships in your organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By LabelCssSelector => By.CssSelector(".govuk-form-group");

        public TellUsWhoHasOverallAccountabilityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", applydataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", applydataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", applydataHelpers.ContactNumber);
            Continue();
            return new ApplicationOverviewPage(_context);
        }

    }
}


