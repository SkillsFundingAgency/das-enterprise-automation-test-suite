using SFA.DAS.Mailinator.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Helpers;

public class MailinatorStepsHelper(ScenarioContext context, string email)
{
    private readonly TabHelper _tabHelper = context.Get<TabHelper>();

    public void OpenLink(string linktext)
    {
        var page = OpenEmail();

        _tabHelper.OpenInNewTab(() => page.OpenLink(linktext));
    }

    private MailinatorEmailPage OpenEmail()
    {
        _tabHelper.OpenInNewTab("https://www.mailinator.com/");

        return new MailinatorLandingPage(context).EnterEmailAndClickOnGoButton(email).OpenEmail();
    }
}
