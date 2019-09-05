using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    public class LoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public LoginHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public bool IsIndexPageDisplayed()
        {
            return new CheckIndexPage(_context)
                .IsIndexPageDisplayed();
        }

        public HomePage Login(LoginUser loginUser)
        {
            return new IndexPage(_context)
                .SignIn()
                .Login(loginUser);
        }

        internal void SetLoginCredentials(LoginUser loginUser)
        {
            _objectContext.SetLoginCredentials(loginUser.Username, loginUser.Password);
            TestContext.Progress.WriteLine($"Email : {loginUser.Username}");
        }
    }
}
