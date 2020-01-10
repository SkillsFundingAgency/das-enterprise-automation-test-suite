using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => objectContext.GetUkprn();

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        protected By CreateACohortLink => By.LinkText("Create a cohort");

        protected By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        protected By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public bool CreateCohortPermissionLinkIsDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(CreateACohortLink);
        }
    }
}
