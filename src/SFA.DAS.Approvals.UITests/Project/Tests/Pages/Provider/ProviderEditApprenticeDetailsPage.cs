using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : ProviderEditApprenticeCoursePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By Uln => By.Id("Uln");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveButton => By.CssSelector("#addApprenticeship > button");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        public ProviderApproveApprenticeDetailsPage EnterUlnAndSave()
        {
            bool rpl = false;

            EnterUln();

            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear)) > 2021) rpl = true;

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage SelectSaveAndUpdateRPLAsNo()
        {
            bool rpl = false;

            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear)) > 2021) rpl = true;
            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();
            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditAllApprenticeDetailsExceptCourse()
        {
            bool rpl = false;

            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            EnterUln();

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

            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear)) > 2021) rpl = true;

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

            formCompletionHelper.ClickElement(SaveButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(context);
        }

        public ProviderEditApprenticeDetailsPage ValidateEditableTextBoxes(int numberOfExpectedTextBoxes)
        {
            GetAllEditBoxes();

            int numberOfTextBoxesDisplayed = GetAllEditBoxes().Count;

            if (numberOfTextBoxesDisplayed != numberOfExpectedTextBoxes)
                throw new Exception($"expected editable boxes were: [{numberOfExpectedTextBoxes}] actual editable boxes displayed are: [{numberOfTextBoxesDisplayed}]");
            else
                return this;
        }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        private void EnterUln()
        {
            var uln = apprenticeDataHelper.Uln();

            if (objectContext.IsSameApprentice() && apprenticeDataHelper.Ulns.Count == 1) uln = apprenticeDataHelper.Ulns.First();

            formCompletionHelper.EnterText(Uln, uln);
        }
    }
}