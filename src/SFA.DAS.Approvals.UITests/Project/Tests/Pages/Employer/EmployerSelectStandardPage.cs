using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EmployerSelectStandardPage(ScenarioContext context) : AddAndEditApprenticeDetailsBasePage(context)
    {
        protected override string PageTitle => "What is the training course?";
        protected override By PageHeader => By.ClassName("govuk-heading-l");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By TrainingCourseContainer => By.CssSelector("#CourseCode");
        private static By TrainingCourseList => By.CssSelector("#CourseCode-select");
        private static By FirstOption => By.CssSelector("#CourseCode__option--0");

        public AddLearnerDetailsPage EmployerSelectsAStandard()
        {
            SelectStandardAndContinue();

            return new AddLearnerDetailsPage(context);
        }

        public AddLearnerDetailsPage VerifyCourseIsPrePopulated()
        {
            pageInteractionHelper.FindElement(FirstOption);
            Continue();
            return new AddLearnerDetailsPage(context);
        }

        public SelectDeliveryModelPage SelectsAStandardAndNavigatesToSelectDeliveryModelPage() => NavigatesToSelectDeliveryModelPage();

        public AddLearnerDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

        public EditLearnerDetailsPage EmployerSelectsAnotherCourse(string CourseTitle)
        {
            SelectStandardAndContinue(CourseTitle);

            return new EditLearnerDetailsPage(context);
        }

        public EditLearnerDetailsPage EmployerSelectsAnotherCourse() => EmployerSelectsAnotherCourse(apprenticeCourseDataHelper.OtherCourseDetails.Course.title);

        private SelectDeliveryModelPage NavigatesToSelectDeliveryModelPage()
        {
            SelectStandardAndContinue();

            return new SelectDeliveryModelPage(context);
        }

        private void SelectStandardAndContinue() => SelectStandardAndContinue(apprenticeCourseDataHelper.CourseDetails.Course.title);

        private void SelectStandardAndContinue(string courseTitle)
        {
            formCompletionHelper.ClickElement
                (() => 
                    { javaScriptHelper.SetTextUsingJavaScript(TrainingCourseContainer, ""); 
                        formCompletionHelper.EnterText(TrainingCourseContainer, courseTitle); 
                        return pageInteractionHelper.FindElement(FirstOption); 
                    }
                );

            Continue();
        }

        private AddLearnerDetailsPage AssertOnlyStandardCoursesAreSelectable()
        {
            var x = GetAllTrainingCourses();
            Assert.That(GetAllTrainingCourses().All(x => !x.Contains("(Framework)") && !x.Contains("(Apprenticeship unit)")), Is.True);
            Continue();
            return new AddLearnerDetailsPage(context);
        }

        private List<string> GetAllTrainingCourses() => formCompletionHelper.GetAllDropDownOptions(TrainingCourseList);
    }
}
