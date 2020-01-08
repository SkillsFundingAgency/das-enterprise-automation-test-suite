using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class LoginCredentialsHelper
    {
        private readonly ObjectContext _objectContext;

        public LoginCredentialsHelper(ObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        public bool IsLevy { get; private set; }

        internal void SetLoginCredentials(LoginUser loginUser, bool isLevy)
        {
            _objectContext.SetLoginCredentials(loginUser.Username, loginUser.Password);
            IsLevy = isLevy;
            Reportusername(loginUser.Username);
        }

        internal void SetLoginCredentials(string username, string password)
        {
            _objectContext.SetLoginCredentials(username, password);
            Reportusername(username);
        }

        public void SetIsLevy()
        {
            IsLevy = true;
        }

        public LoginUser GetLoginCredentials()
        {
            return _objectContext.GetLoginCredentials();
        }

        private void Reportusername(string username)
        {
            TestContext.Progress.WriteLine($"Email : {username}");
        }
    }
}
