using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class ProviderLeadRegistrationHomePage : ProviderHomePage
    {
        #region Helpers and Context
        
        #endregion

        public ProviderLeadRegistrationHomePage(ScenarioContext context) : base(context, true) {  }

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