using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeCoursePage : EditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        private By TrainingCourseEditLink => By.Name("ChangeCourse");

        public ProviderEditApprenticeCoursePage(ScenarioContext context) : base(context)  { }

        public SelectStandardPage ClickEditCourseLink()
        {
            formCompletionHelper.Click(TrainingCourseEditLink);
            return new SelectStandardPage(context);
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

        protected override void EditCourse() => ClickEditCourseLink().SelectAStandardForEditApprenticeDetailsPath();

        private ProviderConfirmChangesPage ProviderConfirmChangesPage() => new ProviderConfirmChangesPage(context);
    }
}
