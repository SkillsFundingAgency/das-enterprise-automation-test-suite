namespace SFA.DAS.Registration.UITests.Project
{
    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    
    public class ProviderPermissionLevyUser : LoginUser { }

    public class AgreementNotSignedTransfersUser : LoginUser { }

    public class TransfersUser : LoginUser { }

    public class LevyUser : LoginUser { }

    public class NonLevyUser : LoginUser { }

    public class EoiUser : LoginUser { }

    public class LoggedInUser : LoginUser { }
}
