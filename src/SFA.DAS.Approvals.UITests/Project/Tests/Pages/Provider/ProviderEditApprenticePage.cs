using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By CourseCode => By.Id("CourseCode");
        private By SearchCourse => By.CssSelector(".select2-search__field");

        public ProviderEditApprenticePage(ScenarioContext context) : base(context) => _context = context;

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
            formCompletionHelper.EnterText(SearchCourse, course);
            formCompletionHelper.SendKeys(SearchCourse, Keys.Enter);
        }


        private ProviderConfirmChangesPage ProviderConfirmChangesPage() => new ProviderConfirmChangesPage(_context);
    }
}
