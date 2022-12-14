using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeTrainingDetailsPage : ProviderEditApprenticeCoursePage
    {
        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
        protected override string PageTitle => "Edit training details";
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveButton => By.XPath("//button[text()='Save']");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");
        private By ActualStartDateDay => By.Id("ActualStartDay");
        public By ActualStartDateMonth => By.Id("ActualStartMonth");
        public By ActualStartDateYear => By.Id("ActualStartYear");
        private static By EditDeliveryModelLink => By.CssSelector("#change-delivery-model-link");

        public ProviderEditApprenticeTrainingDetailsPage(ScenarioContext context) : base(context) { }

        public ProviderApproveApprenticeDetailsPage CheckRPLConditionAndSave(bool isPilotLearner = false)
        {
            if (isPilotLearner) AddActualStartDateDay(apprenticeCourseDataHelper.CourseStartDate);

            bool rpl = CheckRPLCondition(false, isPilotLearner);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private void AddActualStartDateDay(DateTime dateTime) => formCompletionHelper.EnterText(ActualStartDateDay, dateTime.Day);

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

        private bool CheckRPLCondition(bool rpl = false, bool isPilotLearner = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(isPilotLearner ? ActualStartDateYear : StartDateYear));

            var month = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(isPilotLearner ? ActualStartDateMonth : StartDateMonth));

            if (month > 7 & year == 2022) rpl = true;
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

        public ProviderOverlappingTrainingDateThereMayBeProblemPage ClickSaveWhenOltd()
        {
            formCompletionHelper.ClickElement(SaveButton);
            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage EditCost(int cost)
        {
            formCompletionHelper.EnterText(TrainingCost, cost);
            return this;
        }

        public SelectDeliveryModelPage ClickEditDeliveryModel()
        {
            formCompletionHelper.ClickElement(EditDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage EditStartDate(string month, string year)
        {
            EnterText(StartDateMonth, month);
            EnterText(StartDateYear, year);
            return this;
        }

        public ProviderEditApprenticeTrainingDetailsPage EditEndDate(string month, string year)
        {
            EnterText(EndDateMonth, month);
            EnterText(EndDateYear, year);
            return this;
        }

        private void EnterText(By by, string text) => formCompletionHelper.EnterText(by, text);
    }
}
