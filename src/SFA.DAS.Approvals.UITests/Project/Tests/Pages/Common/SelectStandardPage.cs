using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectStandardPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select standard";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public SelectStandardPage(ScenarioContext context) : base(context) { }

        public ProviderAddApprenticeDetailsPage SelectAStandard()
        {
            SelectStandard(apprenticeCourseDataHelper.CourseLarsCode);
            Continue();
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
    }
}
