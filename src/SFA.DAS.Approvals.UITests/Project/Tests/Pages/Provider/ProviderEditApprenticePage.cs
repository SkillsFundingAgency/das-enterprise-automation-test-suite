using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        protected override By Reference => By.Id("ProviderRef");
        protected override By UpdateDetailsButton => By.Id("submit-edit-details");

        public ProviderEditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }

        public new ProviderConfirmChangesPage EditCostAndCourse()
        {
            base.EditCostAndCourse();
            return ProviderConfirmChangesPage();
        }

        public ProviderConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(_dataHelper.ProviderRefernce);
            return ProviderConfirmChangesPage();
        }

        private ProviderConfirmChangesPage ProviderConfirmChangesPage()
        {
            return new ProviderConfirmChangesPage(_context);
        }
    }
}
