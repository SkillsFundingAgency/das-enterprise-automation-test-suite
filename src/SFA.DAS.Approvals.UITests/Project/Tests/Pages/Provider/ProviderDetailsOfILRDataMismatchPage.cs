using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDetailsOfILRDataMismatchPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Details of ILR data mismatch";
        private static By FixILRMismatchOptions => By.XPath("//input[@value='Confirm']");
        protected override By ContinueButton => By.Id("fix-mismatch");
        private static By PriceMismatchRow => By.XPath("//*[text() = 'training price']");
        private static By CourseMismatchRow => By.XPath("//*[text() = 'training course']");
        private static By CourseMismatchRow2 => By.CssSelector("#new-course-name");

        internal ProviderChangeApprenticeDetailsPage RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
        {
            javaScriptHelper.ClickElement(FixILRMismatchOptions);
            Continue();
            return new ProviderChangeApprenticeDetailsPage(context);
        }

        internal ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-Confirm");
            Continue();
            return new ProviderAccessDeniedPage(context);
        }

        internal ProviderApprenticeDetailsPage ClickLeaveForNow()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(FixILRMismatchOptions, "SubmitStatusViewModel-None");
            Continue();
            return new ProviderApprenticeDetailsPage(context);
        }

        public ProviderDetailsOfILRDataMismatchPage SelectILRDataMismatchOptions()
        {
            Continue();
            return this;
        }

        public Dictionary<string, int?> GetRowCountForMismatch()
        {
            Dictionary<string, int?> mismatchRows = [];
            var courseMismatchRows = pageInteractionHelper.FindElements(CourseMismatchRow).Count + pageInteractionHelper.FindElements(CourseMismatchRow2).Count;
            var priceMismatchRows = pageInteractionHelper.FindElements(PriceMismatchRow).Count;
            mismatchRows.Add("CourseMismatchRows", courseMismatchRows);
            mismatchRows.Add("PriceMismatchRows", priceMismatchRows);

            return mismatchRows;
        }


    }
}