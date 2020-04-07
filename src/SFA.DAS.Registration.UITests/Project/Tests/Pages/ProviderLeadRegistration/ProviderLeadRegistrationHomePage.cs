using TechTalk.SpecFlow;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Pages;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class ProviderLeadRegistrationHomePage : ProviderHomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderLeadRegistrationHomePage(ScenarioContext context) : base(context, true) { }

        public IdamsPage SetupEmployerAccount()
        {
            formCompletionHelper.ClickElement(SetupEmployer);
            return new IdamsPage(_context);
        }

        public InvitedEmployersPage ViewInvitedEmployers()
        {
            formCompletionHelper.ClickElement(InvitedEmployers);
            return new InvitedEmployersPage(_context);
        }
    }
}