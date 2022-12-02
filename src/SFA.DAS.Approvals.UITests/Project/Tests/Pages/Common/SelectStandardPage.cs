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

        public AddPersonalDetailsPage EmployerSelectsAStandard()
        {
            SelectStandardAndContinue();
            return new AddPersonalDetailsPage(context);
        }

        public SelectDeliveryModelPage EmployerSelectsASStandardInFlexiJobJourney() => NavigatesToSelectDeliveryModelPage();

        public ProviderAddPersonalDetailsPage ProviderSelectsAStandard()
        {
            SelectStandardAndContinue();
            return new ProviderAddPersonalDetailsPage(context);
        }

        public SelectDeliveryModelPage ProviderSelectsAStandardAndNavigatesToSelectDeliveryModelPage() => NavigatesToSelectDeliveryModelPage();


        public SelectDeliveryModelPage EmployerSelectsAPortableFlexiJobCourse()
        {
            SelectStandard(apprenticeCourseDataHelper.PortableFlexiJobCourseDetails.Course.larsCode);
            Continue();
            return new SelectDeliveryModelPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage ProviderSelectsAStandardForEditApprenticeDetailsPathPreApproval()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new ProviderEditApprenticeTrainingDetailsPage(context);
        }

        public ProviderEditApprenticePersonalDetailsPage ProviderSelectsAStandardForEditApprenticeDetailsPathPostApproval()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new ProviderEditApprenticePersonalDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerSelectsAStandardForEditApprenticeDetailsPath()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return new ProviderEditApprenticeTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

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

        private ProviderEditApprenticePersonalDetailsPage GoToProviderEditApprenticeDetailsPage() => new ProviderEditApprenticePersonalDetailsPage(context);

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

        private AddTrainingDetailsPage AssertOnlyStandardCoursesAreSelectable()
        {
            Assert.True(GetAllTrainingCourses().All(x => !x.Contains("(Framework)")));
            Continue();
            return new AddTrainingDetailsPage(context);
        }

        private List<string> GetAllTrainingCourses() => formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
    }
}
