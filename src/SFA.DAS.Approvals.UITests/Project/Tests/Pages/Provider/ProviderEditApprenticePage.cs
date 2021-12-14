using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice";

        private By CourseOption => By.CssSelector("#trainingCourse");
        private By FirstOption => By.CssSelector("#trainingCourse__option--0");
        
        public ProviderEditApprenticePage(ScenarioContext context) : base(context)  { }

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

        protected override void SelectCourse()
        {
            var course = (editedApprenticeCourseDataHelper.EditedCourse == "91") ? "Software Tester" : "Able Seafarer";
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(CourseOption, course); return pageInteractionHelper.FindElement(FirstOption); });
        }

        private ProviderConfirmChangesPage ProviderConfirmChangesPage() => new ProviderConfirmChangesPage(context);
    }
}
