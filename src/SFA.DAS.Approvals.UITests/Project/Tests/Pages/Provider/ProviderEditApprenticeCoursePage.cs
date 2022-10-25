using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeCoursePage : EditApprenticeDetailsBasePage
    {
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly string _pageTitle;
        #endregion

        public ProviderEditApprenticeCoursePage(ScenarioContext context) : base(context, false)
        {
            _pageTitle = DeterminePageTitle();
            VerifyPage();
        }

        public string DeterminePageTitle()
        {
            var title = pageInteractionHelper.GetUrl().Contains("/unapproved/")
                ? "Edit personal details"
                : "Edit apprentice details";

            return title;
        }

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
