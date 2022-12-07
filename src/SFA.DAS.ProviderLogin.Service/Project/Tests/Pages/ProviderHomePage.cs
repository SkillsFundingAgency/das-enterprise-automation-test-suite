using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => ukprn;

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        protected By AddNewApprenticesLink => By.LinkText("Add new apprentices");

        protected By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected By GetFundingLink => By.LinkText("Get funding for non-levy employers");

        protected By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

        protected By ManageEmployerInvitations => By.LinkText("Manage employer invitations");

        protected By InviteEmployers => By.LinkText("Send invitation to employer");
        protected By RecruitTrainees => By.LinkText("Recruit trainees");
        protected By AppsIndicativeEarningsReport => By.LinkText("Apps Indicative earnings report");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => AcceptCookies();
        
    }
}