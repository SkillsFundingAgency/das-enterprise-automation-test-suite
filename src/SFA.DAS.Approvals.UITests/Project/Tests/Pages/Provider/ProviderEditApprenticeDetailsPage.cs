using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dynamitey;
using NUnit.Framework;
using TechTalk.SpecFlow;

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
        private By SaveButton => By.CssSelector(".govuk-button");
        private By DeleteButton => By.LinkText("Delete");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderReviewYourCohortPage EnterUlnAndSave()
        {
            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
            formCompletionHelper.ClickElement(SaveButton);
            return new ProviderReviewYourCohortPage(_context);
        }

        public ProviderReviewYourCohortPage EditAllApprenticeDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
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
            return new ProviderReviewYourCohortPage(_context);
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(_context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable()
        {
            var options = formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
            Assert.True(options.All(x => x.Contains("(Standard)")));
            return this;
        }
    }
}