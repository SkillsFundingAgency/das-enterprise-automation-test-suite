using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDetailsOfILRDataMismatchPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Details of ILR data mismatch";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By FixILRMismatchOptions => By.XPath("//input[@value='Confirm']");
        protected override By ContinueButton => By.Id("fix-mismatch");
        private By PriceMismatchRow => By.XPath("//*[text() = 'training price']");
        private By CourseMismatchRow => By.XPath("//*[text() = 'training course']");
        private By CourseMismatchRow2 => By.CssSelector("#new-course-name");

        public ProviderDetailsOfILRDataMismatchPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderChangeApprenticeDetailsPage RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
        {
            javaScriptHelper.ClickElement(FixILRMismatchOptions);
            Continue();
            return new ProviderChangeApprenticeDetailsPage(_context);
        }

        internal ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            Continue();            
            return new ProviderAccessDeniedPage(_context);
        }

        internal ProviderApprenticeDetailsPage ClickLeaveForNow()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-None");
            Continue();
            return new ProviderApprenticeDetailsPage(_context);
        }

        public ProviderDetailsOfILRDataMismatchPage SelectILRDataMismatchOptions()
        {
            Continue();
            return this;
        }

        public Dictionary<string, int?> GetRowCountForMismatch()
        {
            Dictionary<string, int?> mismatchRows = new Dictionary<string, int?>();
            var courseMismatchRows = pageInteractionHelper.FindElements(CourseMismatchRow).Count + pageInteractionHelper.FindElements(CourseMismatchRow2).Count;
            var priceMismatchRows = pageInteractionHelper.FindElements(PriceMismatchRow).Count;
            mismatchRows.Add("CourseMismatchRows", courseMismatchRows);
            mismatchRows.Add("PriceMismatchRows", priceMismatchRows);

            return mismatchRows;
        }


    }
}