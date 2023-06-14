using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectStandardPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select standard";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private static By TrainingCourseContainer => By.CssSelector("#CourseCode");

        private static By AddStandardsDDL => By.CssSelector("#SelectedLarsCode");

        private static By FirstItemInTheList => By.CssSelector("#SelectedLarsCode__option--0");

        public SelectStandardPage(ScenarioContext context) : base(context) { }

        //this method is used to add test data (standard) to the provider. Should not be used in the regression tests
        public ProviderAddStandardGenericPage AddStandard()
        {
            formCompletionHelper.Click(AddStandardsDDL);
            formCompletionHelper.Click(FirstItemInTheList);
            Continue();
            return new ProviderAddStandardGenericPage(context);
        }

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

        public ProviderAddApprenticeDetailsPage ProviderSelectsAStandardForFlexiPaymentsPilot()
        {
            SelectStandardAndContinue();

            return new ProviderAddApprenticeDetailsPage(context, true);
        }

        public SelectDeliveryModelPage SelectsAStandardAndNavigatesToSelectDeliveryModelPage() => NavigatesToSelectDeliveryModelPage();

        public ProviderEditApprenticeDetailsPage ProviderSelectsAStandardForEditApprenticeDetails()
        {
            SelectStandardAndContinue(apprenticeCourseDataHelper.OtherCourseLarsCode);

            return new ProviderEditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public AddApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

        public EditApprenticeDetailsPage EmployerSelectsAnotherCourse(string LarsCode)
        {
            SelectStandardAndContinue(LarsCode);

            return new EditApprenticeDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerSelectsAnotherCourse() => EmployerSelectsAnotherCourse(apprenticeCourseDataHelper.OtherCourseLarsCode);
        
        private SelectDeliveryModelPage NavigatesToSelectDeliveryModelPage()
        {
            SelectStandardAndContinue();

            return new SelectDeliveryModelPage(context);
        }

        private void SelectStandardAndContinue() => SelectStandardAndContinue(apprenticeCourseDataHelper.CourseLarsCode);

        private void SelectStandardAndContinue(string courseLarsCode)
        {
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, courseLarsCode);

            Continue();
        }

        public void AssertStandardIsNotAvailable()
        {
            var courseDetails = apprenticeCourseDataHelper.CourseDetails;

            Assert.That(formCompletionHelper.GetAllDropDownValue(TrainingCourseContainer).Any(x=> x == courseDetails.Course.larsCode), Is.False, $"{courseDetails.Course.larsCode}, {courseDetails.Course.title} is available for the provider");
        }

        private void AssertStandardAndFrameworkCoursesAreSelectable() => Assert.That(GetAllTrainingCourses().All(x => x.Contains("(Framework)")), Is.False);

        private AddApprenticeDetailsPage AssertOnlyStandardCoursesAreSelectable()
        {
            Assert.That(GetAllTrainingCourses().All(x => !x.Contains("(Framework)")), Is.True);
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

        private List<string> GetAllTrainingCourses() => formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
    }
}
