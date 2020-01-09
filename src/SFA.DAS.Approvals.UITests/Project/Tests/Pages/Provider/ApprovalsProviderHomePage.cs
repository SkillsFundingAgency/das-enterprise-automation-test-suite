using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ApprovalsProviderHomePage : ProviderHomePage
    {

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ApprovalsProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ProviderManageYourApprenticesPage GoToProviderManageYourApprenticePage()
        {
            _formCompletionHelper.ClickElement(ProviderManageYourApprenticesLink);
            return new ProviderManageYourApprenticesPage(_context);
        }

        public ProviderNotificationSettingsPage GoToProviderNotificationSettingsPage()
        {
            _formCompletionHelper.ClickElement(NotificationSettingsLink);
            return new ProviderNotificationSettingsPage(_context);
        }

        public ProviderChooseAnEmployerNonLevyPage GotoChooseAnEmployerNonLevyPage()
        {
            _formCompletionHelper.ClickElement(CreateACohortLink);
            return new ProviderChooseAnEmployerNonLevyPage(_context);
        }

        public ProviderReserveFundingForNonLevyEmployersPage GoToProviderGetFunding()
        {
            _formCompletionHelper.ClickElement(GetFundingLink);
            return new ProviderReserveFundingForNonLevyEmployersPage(_context);
        }

        public ProviderFundingForNonLevyEmployersPage GoToManageYourFunding()
        {
            _formCompletionHelper.ClickElement(ManageYourFundingLink);
            return new ProviderFundingForNonLevyEmployersPage(_context);
        }
    }
}
