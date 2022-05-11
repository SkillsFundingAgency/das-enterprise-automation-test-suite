using TechTalk.SpecFlow;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Pages;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class ProviderLeadRegistrationHomePage : ProviderHomePage
    {
        #region Helpers and Context
        
        #endregion

        public ProviderLeadRegistrationHomePage(ScenarioContext context) : base(context, true) {  }

        public void SetupEmployerAccount()
        {
            formCompletionHelper.ClickElement(ManageEmployerInvitations);
            formCompletionHelper.ClickElement(PireanPreprod);
            formCompletionHelper.ClickElement(InviteEmployers);
         
        }

        public InvitedEmployersPage ViewInvitedEmployers()
        {
            formCompletionHelper.ClickElement(ManageEmployerInvitations);

            return new InvitedEmployersPage(context);
        }
    }
}