using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeCoursePage : EditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        public ProviderEditApprenticeCoursePage(ScenarioContext context) : base(context) { }

        public ProviderConfirmChangesPage AddValidEmailAndContinue()
        {
            EditEmail();
            return ProviderConfirmChangesPage();
        }

        public ProviderConfirmChangesPage EditCostCourseAndReference()
        {
            EditCostCourseAndReference(editedApprenticeDataHelper.ProviderRefernce);
            return ProviderConfirmChangesPage();
        }

        public ProviderConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.ProviderRefernce);
            return ProviderConfirmChangesPage();
        }

        protected override void EditCourse() => ClickEditCourseLink().ProviderSelectsAStandardForEditApprenticeDetailsPath();

        private ProviderConfirmChangesPage ProviderConfirmChangesPage() => new ProviderConfirmChangesPage(context);
    }
}
