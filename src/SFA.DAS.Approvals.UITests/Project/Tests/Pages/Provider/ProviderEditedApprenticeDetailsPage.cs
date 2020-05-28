using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditedApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _cocDataHelper.ApprenticeEditedFullName;

        private readonly EditedApprenticeDataHelper _cocDataHelper;

        public ProviderEditedApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _cocDataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }
    }
}
