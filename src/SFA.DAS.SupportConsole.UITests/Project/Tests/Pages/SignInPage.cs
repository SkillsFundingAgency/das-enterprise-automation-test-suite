using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SignInPage(ScenarioContext context) : base(context) => _context = context;          

        public SearchHomePage SignInWithValidDetails(LoginUser usercreds)
        {
            SubmitValidLoginDetails(usercreds.Username, usercreds.Password);

            return new SearchHomePage(_context);
        }
    }
}
