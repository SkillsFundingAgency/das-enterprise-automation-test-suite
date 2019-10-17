using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditedApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _dataHelper.ApprenticeEditedFullName;

        #region Helpers and Context
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        public EditedApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }
    }
}