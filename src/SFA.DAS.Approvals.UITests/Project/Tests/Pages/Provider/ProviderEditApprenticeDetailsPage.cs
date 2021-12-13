using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Edit apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By Uln => By.Id("Uln");
        private By TrainingCourseContainer => By.Id("CourseCode");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveButton => By.CssSelector("#addApprenticeship > button");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        public ProviderApproveApprenticeDetailsPage EnterUlnAndSave()
        {
            EnterUln();
            
            formCompletionHelper.ClickElement(SaveButton);

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditAllApprenticeDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            EnterUln();
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, apprenticeCourseDataHelper.Course);
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
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingPrice);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            formCompletionHelper.ClickElement(SaveButton);

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
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingPrice);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            formCompletionHelper.ClickElement(SaveButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable()
        {
            var options = formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
            Assert.False(options.All(x => x.Contains("(Framework)")));
            return this;
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