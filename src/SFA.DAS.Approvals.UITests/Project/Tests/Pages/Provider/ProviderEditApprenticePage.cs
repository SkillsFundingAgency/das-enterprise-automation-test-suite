using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeDataHelper _dataHelper;
        private readonly EditedApprenticeCourseDataHelper _coursedataHelper;
        #endregion
        protected By CourseCode => By.Id("CourseCode");

        public ProviderEditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            _coursedataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            VerifyPage();
        }

        public ProviderConfirmChangesPage EditCostCourseAndReference()
        {
            EditCostCourseAndReference(_dataHelper.ProviderRefernce);
            return ProviderConfirmChangesPage();
        }

        public ProviderConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(_dataHelper.ProviderRefernce);
            return ProviderConfirmChangesPage();
        }

        protected override void SelectCourse()
        {
            formCompletionHelper.SelectFromDropDownByValue(CourseCode, _coursedataHelper.EditedCourse);
        }

        private ProviderConfirmChangesPage ProviderConfirmChangesPage()
        {
            return new ProviderConfirmChangesPage(_context);
        }
    }
}
