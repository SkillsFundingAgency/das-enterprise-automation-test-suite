using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderHomePage : InterimProviderBasePage
{
    protected override string AccessibilityPageTitle => "Provider Home Page";

    public static By Identifier => By.CssSelector("#content, #main-content");

    protected override string PageTitle => ukprn;

    protected override By PageHeader => Identifier;

    protected override string Linktext => "Home";

    protected static By AddNewApprenticesLink => By.LinkText("Add new apprentices");

    protected static By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

    protected static By GetFundingLink => By.LinkText("Get funding for non-levy employers");

    protected static By ManageYourFundingLink => By.LinkText("Manage your funding reserved for non-levy employers");

    protected static By ManageEmployerInvitations => By.LinkText("Manage employer invitations");

    protected static By InviteEmployers => By.LinkText("Send invitation to employer");

    protected static By RecruitTrainees => By.LinkText("Recruit trainees");

    protected static By AppsIndicativeEarningsReport => By.LinkText("Apps Indicative earnings report");

    protected static By YourStandardsAndTrainingVenues => By.LinkText("Your standards and training venues");

    public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => AcceptCookies();

}