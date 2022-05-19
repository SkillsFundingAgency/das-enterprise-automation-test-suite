using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectStandardPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select standard";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

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

        public ProviderEditApprenticeDetailsPage SelectAStandardForEditApprenticeDetailsPath()
        {
            SelectStandard(apprenticeCourseDataHelper.OtherCourseLarsCode);
            Continue();
            return GoToProviderEditApprenticeDetailsPage();
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            AssertStandardAndFrameworkCoursesAreSelectable();
            Continue();
            return GoToProviderEditApprenticeDetailsPage();
        }

        private ProviderEditApprenticeDetailsPage GoToProviderEditApprenticeDetailsPage() => new ProviderEditApprenticeDetailsPage(context);

        private void SelectStandardAndContinue()
        {
            SelectStandard(apprenticeCourseDataHelper.CourseLarsCode);
            Continue();
        }
    }
}
