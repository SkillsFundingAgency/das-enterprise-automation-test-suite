using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssessmentOverviewPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Financial health assessment overview";

        private By DayOutStandingField => By.Id("OutstandingFinancialDueDate.Day");
        private By MonthOutStandingField => By.Id("OutstandingFinancialDueDate.Month");
        private By YearOutStandingField => By.Id("OutstandingFinancialDueDate.Year");
        private By ClarificationCommentBox => By.Id("ClarificationComments");
        private By ClarificationResponseBox => By.Id("ClarificationResponse");
        private By InadequateCommentBox => By.Id("InadequateComments");
        private By UploadClarificationFileButton => By.CssSelector(".govuk-button--secondary");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssessmentOverviewPage(ScenarioContext context) : base(context)
        {
           _context = context;
           VerifyPage();
        }

        public FinancialHealthAssesmentCompletedPage ConfirmFHAReviewAsOutstanding()
        {
            SelectRadioOptionByForAttribute("outstanding");
            formCompletionHelper.EnterText(DayOutStandingField, "1");
            formCompletionHelper.EnterText(MonthOutStandingField, "2");
            formCompletionHelper.EnterText(YearOutStandingField, "2022");
            Continue();
            return new FinancialHealthAssesmentCompletedPage(_context);
        }

        public FinancialHealthAssesmentCompletedPage ConfirmNeedsClarification()
        {
            SelectRadioOptionByForAttribute("clarification");
            formCompletionHelper.EnterText(ClarificationCommentBox, "PMO Clarification Internal Comments");
            Continue();
            return new FinancialHealthAssesmentCompletedPage(_context);
        }

        public FinancialHealthAssesmentCompletedPage EnterClarificationResponse()
        {
            formCompletionHelper.EnterText(ClarificationResponseBox, "Clarification Response Comments");
            UploadFile();
            RemoveOneFile();
            SelectRadioOptionByForAttribute("inadequate");
            formCompletionHelper.EnterText(InadequateCommentBox, "PMO Clarification Internal Comments for Inadequate");
            Continue();
            return new FinancialHealthAssesmentCompletedPage(_context);
        }

        private FinancialHealthAssessmentOverviewPage UploadFile()
        {
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            return this;
        }

        private FinancialHealthAssessmentOverviewPage RemoveOneFile()
        {
            formCompletionHelper.ClickLinkByText("Remove");
            return this;
        }
    }
}