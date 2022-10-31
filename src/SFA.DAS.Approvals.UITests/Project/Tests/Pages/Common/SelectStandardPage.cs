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

        public SelectDeliveryModelPage EmployerSelectsASStandardInFlexiJobJourney() => NavigatesToSelectDeliveryModelPage();

        public ProviderAddApprenticeDetailsPage ProviderSelectsAStandard()
        {
            SelectStandardAndContinue();
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public SelectDeliveryModelPage ProviderSelectsAStandardAndNavigatesToSelectDeliveryModelPage() => NavigatesToSelectDeliveryModelPage();
        
        public SelectDeliveryModelPage EmployerSelectsAPortableFlexiJobCourse()
        {
            SelectStandard(apprenticeCourseDataHelper.PortableFlexiJobCourseDetails.Course.larsCode);
            Continue();
            return new SelectDeliveryModelPage(context);
        }

        public ProviderEditApprenticeDetailsPage ProviderSelectsAStandardForEditApprenticeDetailsPath()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return GoToProviderEditApprenticeDetailsPage();
        }

        public EditApprenticePage EmployerSelectsAStandardForEditApprenticeDetailsPath()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return new EditApprenticePage(context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return GoToProviderEditApprenticeDetailsPage();
        }

        public AddApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

        public EditApprenticePage EmployerSelectsAnotherCourse()
        {
            var selectedCourse = formCompletionHelper.GetSelectedOption(TrainingCourseContainer);
            formCompletionHelper.SelectFromDropDownByText(TrainingCourseContainer, GetAnyStandardCourse(selectedCourse));
            Continue();
            return new EditApprenticePage(context);
        }

        private string GetAnyStandardCourse(string selectedCourseName)
        {
            var availableCourses = new List<string> { "Abattoir worker, Level: 2", "Actuary, Level: 7", "Software tester, Level: 4" };
            availableCourses = availableCourses.Where(x => !x.ContainsCompareCaseInsensitive(selectedCourseName) && x.Contains("Level")).ToList();
            return RandomDataGenerator.GetRandomElementFromListOfElements(availableCourses);
        }

        private ProviderEditApprenticeDetailsPage GoToProviderEditApprenticeDetailsPage() => new ProviderEditApprenticeDetailsPage(context);

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
