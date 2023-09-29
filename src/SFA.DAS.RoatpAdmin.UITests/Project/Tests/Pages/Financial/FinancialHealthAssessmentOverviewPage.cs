using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssessmentOverviewPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Financial health assessment overview";

        private static By DayOutStandingField => By.Id("OutstandingFinancialDueDate.Day");
        private static By MonthOutStandingField => By.Id("OutstandingFinancialDueDate.Month");
        private static By YearOutStandingField => By.Id("OutstandingFinancialDueDate.Year");
        private static By ClarificationCommentBox => By.Id("ClarificationComments");
        private static By ClarificationResponseBox => By.Id("ClarificationResponse");
        private static By InadequateCommentBox => By.Id("InadequateComments");
        private static By InadequateExternalCommentsBox => By.Id("InadequateExternalComments");
        private static By UploadClarificationFileButton => By.CssSelector(".govuk-button--secondary");
        private static By RemoveClarificationFileButton => By.CssSelector("button[name='removeClarificationFile']");

        public FinancialHealthAssessmentOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

        public FinancialHealthAssesmentCompletedPage ConfirmFHAReview(string expectedoutcome)
        {
            SelectRadioOptionByForAttribute(expectedoutcome);
            if (tags.Contains("rpendtoend02apply"))
            {

                formCompletionHelper.EnterText(InadequateCommentBox, "PMO Internal Comments for Inadequate");
                formCompletionHelper.EnterText(InadequateExternalCommentsBox, "PMO External Comments for Inadequate");
                formCompletionHelper.ClickButtonByText(ContinueButton, "Save outcome");
            }
            else
            {
                formCompletionHelper.EnterText(DayOutStandingField, "1");
                formCompletionHelper.EnterText(MonthOutStandingField, "2");
                formCompletionHelper.EnterText(YearOutStandingField, "2025");
                Continue();
            }
            return new FinancialHealthAssesmentCompletedPage(context);
        }

        public FinancialHealthAssesmentCompletedPage ConfirmNeedsClarification()
        {
            SelectRadioOptionByForAttribute("clarification");
            formCompletionHelper.EnterText(ClarificationCommentBox, "PMO Clarification Internal Comments");
            Continue();
            return new FinancialHealthAssesmentCompletedPage(context);
        }

        public FinancialHealthAssesmentCompletedPage EnterClarificationResponse()
        {
            UploadFile();
            RemoveOneFile();
            UploadFile();
            formCompletionHelper.EnterText(ClarificationResponseBox, "Clarification Response Comments");
            SelectRadioOptionByForAttribute("inadequate");
            formCompletionHelper.EnterText(InadequateCommentBox, "PMO Clarification Internal Comments for Inadequate");
            formCompletionHelper.EnterText(InadequateExternalCommentsBox, "PMO Clarification External Comments for Inadequate");
            formCompletionHelper.ClickButtonByText(ContinueButton, "Save outcome");
            return new FinancialHealthAssesmentCompletedPage(context);
        }

        private FinancialHealthAssessmentOverviewPage UploadFile()
        {
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            return this;
        }

        private FinancialHealthAssessmentOverviewPage RemoveOneFile()
        {
            formCompletionHelper.ClickElement(RemoveClarificationFileButton);
            return this;
        }
    }
}