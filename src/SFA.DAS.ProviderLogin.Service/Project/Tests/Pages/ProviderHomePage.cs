using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => ukprn;

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        protected By CreateACohortLink => By.LinkText("Create a cohort");

        protected By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        protected By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        protected By SetupEmployer => By.LinkText("Set up employer account");

        protected By InvitedEmployers => By.LinkText("View invited employers");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) { }

        public bool CreateCohortPermissionLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(CreateACohortLink);
    }
}