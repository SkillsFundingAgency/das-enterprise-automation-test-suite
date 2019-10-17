using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => objectContext.GetUkprn();

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        private By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        private By NotificationSettingsLink => By.LinkText("Notification settings");

        private By CreateACohortLink => By.LinkText("Create a cohort");

        private By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        private By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
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

        public bool CreateCohortPermissionLinkIsDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(CreateACohortLink);
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
