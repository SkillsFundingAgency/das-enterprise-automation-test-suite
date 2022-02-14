using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AmendReasonPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Are you sure this certificate needs amending?";

        #region Helpers and Context
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected By TicketReferenceField => By.Id("IncidentNumber");
        #endregion

        public AmendReasonPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckAndSubmitAssessmentDetailsPage EnterTicketReferenceAndSelectReason()
        {
            formCompletionHelper.EnterText(TicketReferenceField, "1234567890");
            SelectCheckBoxByText("Incorrect apprentice details");
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }
    }
}