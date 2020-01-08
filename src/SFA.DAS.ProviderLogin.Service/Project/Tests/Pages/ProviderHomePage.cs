using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderHomePage : Navigate
    {
        protected override string PageTitle => _objectContext.GetUkprn();

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        protected By CreateACohortLink => By.LinkText("Create a cohort");

        protected By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected By NotificationSettingsLink => By.LinkText("Notification settings");

        protected By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        protected By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        private By SignOutLink => By.LinkText("Sign out");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void SignsOut()
        {
            _formCompletionHelper.ClickElement(SignOutLink);
        }

        public bool CreateCohortPermissionLinkIsDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(CreateACohortLink);
        }
    }
}
