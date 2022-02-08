using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CheckAndSubmitAssessmentDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context

        #endregion

        public CheckAndSubmitAssessmentDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmationAmendPage ClickConfirmAmend()
        {
            Confirm();
            return new ConfirmationAmendPage(context);
        }

        public ConfirmationReprintPage ClickConfirmReprint()
        {
            Confirm();
            return new ConfirmationReprintPage(context);
        }
    }
}