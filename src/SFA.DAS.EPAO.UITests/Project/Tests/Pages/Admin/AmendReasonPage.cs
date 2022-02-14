using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AmendReasonPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Are you sure this certificate needs amending?";

        #region Helpers and Context
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected By IncidentNumberField => By.Id("IncidentNumber");
        #endregion

        public AmendReasonPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckAndSubmitAssessmentDetailsPage EnterTicketRefeferenceAndSelectReason(string ticketReference, string amendReason)
        {
            formCompletionHelper.EnterText(IncidentNumberField, ticketReference);
            SelectCheckBoxByText(amendReason);
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }
    }
}