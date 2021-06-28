using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class LoginCredentialsHelper
    {
        private readonly ObjectContext _objectContext;

        public LoginCredentialsHelper(ObjectContext objectContext) => _objectContext = objectContext;

        public bool IsLevy { get; private set; }

        internal void SetLoginCredentials(string username, string password, string organisationName, bool isLevy = false)
        {
            _objectContext.SetLoginCredentials(username, password, organisationName);

            IsLevy = isLevy;
            
            Reportusername(username);
        }

        public void SetIsLevy() => IsLevy = true;

        public LoginUser GetLoginCredentials() => _objectContext.GetLoginCredentials();

        private void Reportusername(string username) => TestContext.Progress.WriteLine($"Email : {username}");
    }
}
