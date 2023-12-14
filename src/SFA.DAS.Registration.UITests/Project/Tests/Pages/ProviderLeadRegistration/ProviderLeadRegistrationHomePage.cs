using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class ProviderLeadRegistrationHomePage(ScenarioContext context) : ProviderHomePage(context, true)
    {
        public StartSettingUpEmployerPage SetupEmployerAccount()
        {
            formCompletionHelper.ClickElement(ManageEmployerInvitations);

            formCompletionHelper.ClickElement(InviteEmployers);

            return new StartSettingUpEmployerPage(context);
        }

        public InvitedEmployersPage ViewInvitedEmployers()
        {
            formCompletionHelper.ClickElement(ManageEmployerInvitations);

            return new InvitedEmployersPage(context);
        }
    }
}