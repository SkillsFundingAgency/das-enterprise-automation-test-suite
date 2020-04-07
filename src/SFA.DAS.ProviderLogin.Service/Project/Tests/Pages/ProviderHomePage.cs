using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => ukprn;

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By CreateACohortLink => By.LinkText("Create a cohort");

        protected By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        protected By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        protected By SetupEmployer => By.LinkText("Set up employer account");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _context = context;

        public bool CreateCohortPermissionLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(CreateACohortLink);

        public IdamsPage SetupEmployerAccount()
        {
            formCompletionHelper.ClickElement(SetupEmployer);
            return new IdamsPage(_context);
        }
    }
}