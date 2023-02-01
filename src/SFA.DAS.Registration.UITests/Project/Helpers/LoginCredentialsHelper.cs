using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;

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
        }

        public void SetIsLevy() => IsLevy = true;

        public LoggedInAccountUser GetLoginCredentials() => _objectContext.GetLoginCredentials();
    }
}
