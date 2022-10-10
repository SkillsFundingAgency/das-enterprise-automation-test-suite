using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeTrainingDetailsPage : ProviderEditApprenticeCoursePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveButton => By.XPath("//button[text()='Save']");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");

        public ProviderEditApprenticeTrainingDetailsPage(ScenarioContext context) : base(context) { }

        public ProviderApproveApprenticeDetailsPage CheckRPLConditionAndSave()
        {

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage SelectSaveAndUpdateRPLAsNo()
        {
            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();
            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditAllApprenticeDetailsExceptCourse()
        {
            formCompletionHelper.ClickElement(StartDateMonth);
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            if (loginCredentialsHelper.IsLevy == false)
            {
                DateTime now = DateTime.Now;
                formCompletionHelper.EnterText(StartDateMonth, now.Month);
                formCompletionHelper.EnterText(StartDateYear, now.Year);
            }
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditCopApprenticeDetails()
        {
            formCompletionHelper.ClickElement(StartDateMonth);
            DateTime now = DateTime.Now;
            formCompletionHelper.EnterText(StartDateMonth, now.Month);
            formCompletionHelper.EnterText(StartDateYear, now.Year);
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage ValidateEditableTextBoxes(int numberOfExpectedTextBoxes)
        {
            GetAllEditBoxes();

            int numberOfTextBoxesDisplayed = GetAllEditBoxes().Count;

            if (numberOfTextBoxesDisplayed != numberOfExpectedTextBoxes)
                throw new Exception($"expected editable boxes were: [{numberOfExpectedTextBoxes}] actual editable boxes displayed are: [{numberOfTextBoxesDisplayed}]");
            else
                return this;
        }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        private bool CheckRPLCondition(bool rpl = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear));
            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & year == 2022) rpl = true;
            if (year > 2022) rpl = true;
            return rpl;
        }

        public ProviderApproveApprenticeDetailsPage ClickSave()
        {
            bool rpl = CheckRPLCondition(false);
            formCompletionHelper.ClickElement(SaveButton);
            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();
            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
