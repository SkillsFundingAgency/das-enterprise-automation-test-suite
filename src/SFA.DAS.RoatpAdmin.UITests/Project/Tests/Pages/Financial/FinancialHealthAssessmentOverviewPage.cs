using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialHealthAssessmentOverviewPage : FinancialHealthAssesmentBasePage
    {
        protected override string PageTitle => "Financial health assessment overview";

        private By DayOutStandingField => By.Id("OutstandingFinancialDueDate.Day");
        private By MonthOutStandingField => By.Id("OutstandingFinancialDueDate.Month");
        private By YearOutStandingField => By.Id("OutstandingFinancialDueDate.Year");
        private By ClarificationCommentBox => By.Id("ClarificationComments");
        private By ClarificationResponseBox => By.Id("ClarificationResponse");
        private By InadequateCommentBox => By.Id("InadequateComments");
        private By UploadClarificationFileButton = By.CssSelector(".govuk-button--secondary");
        private By OutcomeStatus => By.CssSelector("[data-label='Outcome']");

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

        public FinancialHealthAssesmentBasePage ConfirmNeedsClarification()
        {
            SelectRadioOptionByForAttribute("clarification");
            formCompletionHelper.EnterText(ClarificationCommentBox, "PMO Clarification Internal Comments");
            Continue();
            return new FinancialHealthAssesmentBasePage(_context);
        }

        public FinancialHealthAssesmentCompletedPage EnterClarificationResponse()
        {
            formCompletionHelper.EnterText(ClarificationResponseBox, "Clarification Response Comments");
            UploadFourFiles();
            SelectRadioOptionByForAttribute("inadequate");
            formCompletionHelper.EnterText(InadequateCommentBox, "PMO Clarification Internal Comments for Inadequate");
            Continue();

            return new FinancialHealthAssesmentCompletedPage(_context);
        }

        public FinancialHealthAssesmentBasePage UploadFourFiles()
        {
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            ChooseFile();
            formCompletionHelper.ClickElement(UploadClarificationFileButton);
            return new FinancialHealthAssesmentBasePage(_context);
        }
        public FinancialHealthAssesmentBasePage VerifyOutcomeStatus(string expectedStatus)
        {
            return VerifyApplicationStatus(OutcomeStatus, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OutcomeTab)));
        }

    }
}