using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectStandardPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select standard";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private By TrainingCourseContainer => By.Id("CourseCode");

        public SelectStandardPage(ScenarioContext context) : base(context) { }

        public AddApprenticeDetailsPage EmployerSelectsAStandard()
        {
            SelectStandardAndContinue();
            return new AddApprenticeDetailsPage(context);
        }

        public ProviderAddApprenticeDetailsPage ProviderSelectsAStandard()
        {
            SelectStandardAndContinue();
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public ProviderAddApprenticeDetailsPage ProviderSelectsAStandardForFlexiPaymentsPilot(bool isPilot = false)
        {
            SelectStandardAndContinue();
            return new ProviderAddApprenticeDetailsPage(context, isPilot);
        }

        public SelectDeliveryModelPage SelectsAStandardAndNavigatesToSelectDeliveryModelPage() => NavigatesToSelectDeliveryModelPage();

        public ProviderEditApprenticeDetailsPage ProviderSelectsAStandardForEditApprenticeDetails()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerSelectsAStandardForEditApprenticeDetailsPath()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public AddApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

        public EditApprenticeDetailsPage EmployerSelectsAnotherCourse()
        {
            var selectedCourse = formCompletionHelper.GetSelectedOption(TrainingCourseContainer);
            formCompletionHelper.SelectFromDropDownByText(TrainingCourseContainer, GetAnyStandardCourse(selectedCourse));
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        private string GetAnyStandardCourse(string selectedCourseName)
        {
            var availableCourses = new List<string> { "Abattoir worker, Level: 2", "Actuary, Level: 7", "Software tester, Level: 4" };
            availableCourses = availableCourses.Where(x => !x.ContainsCompareCaseInsensitive(selectedCourseName) && x.Contains("Level")).ToList();
            return RandomDataGenerator.GetRandomElementFromListOfElements(availableCourses);
        }

        private SelectDeliveryModelPage NavigatesToSelectDeliveryModelPage()
        {
            SelectStandardAndContinue();
            return new SelectDeliveryModelPage(context);
        }

        private void SelectStandardAndContinue()
        {
            SelectStandard(apprenticeCourseDataHelper.CourseLarsCode);
            Continue();
        }

        private void SelectStandard(string courseLarsCode) => formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, courseLarsCode);

        private void AssertStandardAndFrameworkCoursesAreSelectable() => Assert.False(GetAllTrainingCourses().All(x => x.Contains("(Framework)")));

        private AddApprenticeDetailsPage AssertOnlyStandardCoursesAreSelectable()
        {
            Assert.True(GetAllTrainingCourses().All(x => !x.Contains("(Framework)")));
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

        private List<string> GetAllTrainingCourses() => formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
    }
}
