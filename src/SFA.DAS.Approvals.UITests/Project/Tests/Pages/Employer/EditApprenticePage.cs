using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        protected override By Reference => By.Id("EmployerRef");
        protected override By UpdateDetailsButton => By.Id("submit-edit-app");


        public EditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }
        public new ConfirmChangesPage EditCostAndCourse()
        {
            base.EditCostAndCourse();
            return ConfirmChangesPage();
        }

        public ConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(_dataHelper.EmployerReference);
            return ConfirmChangesPage();
        }

        private ConfirmChangesPage ConfirmChangesPage()
        {
            return new ConfirmChangesPage(_context);
        }
    }
}