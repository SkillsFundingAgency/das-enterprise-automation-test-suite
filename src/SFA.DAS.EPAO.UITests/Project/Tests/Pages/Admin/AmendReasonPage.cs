using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AmendReasonPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Are you sure this certificate needs amending?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By TicketReferenceField => By.Id("IncidentNumber");

        #region Helpers and Context

        #endregion

        public AmendReasonPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckAndSubmitAssessmentDetailsPage EnterTicketReferenceAndSelectReason(string incidentNumber, string reason)
        {
            formCompletionHelper.EnterText(TicketReferenceField, incidentNumber);
            SelectCheckBoxByText(reason);
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }
    }
}