using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        protected readonly ObjectContext objectContext;
        #endregion

        private By SignOutLink => By.LinkText("Sign out");

        public InterimProviderBasePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderHomePage HomePage()
        {
            return new ProviderHomePage(_context);
        }

        public void SignsOut()
        {
            _formCompletionHelper.ClickElement(SignOutLink);
        }
    }
}
