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
            return GoToEmployerEditApprenticeDetailsPage();
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return GoToProviderEditApprenticeDetailsPage();
        }

        public AddApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable() => AssertOnlyStandardCoursesAreSelectable();

        private ProviderEditApprenticeDetailsPage GoToProviderEditApprenticeDetailsPage() => new ProviderEditApprenticeDetailsPage(context);

        private EditApprenticePage GoToEmployerEditApprenticeDetailsPage() => new EditApprenticePage(context);

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
