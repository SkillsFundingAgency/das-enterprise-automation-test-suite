namespace SFA.DAS.Registration.UITests.Project
{
    public class RegistrationConfig
    {
        public string TwoDigitProjectCode { get; set; }

        public string RE_AccountPassword { get; set; }

        public string Browser { get; set; }

        public string RE_BaseUrl { get; set; }

        public string RE_ConfirmCode { get; set; }

        public string RE_OrganisationName { get; set; }
    }

    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class AgreementNotSignedTransfersUser : LoginUser { }

    public class TransfersUser : LoginUser { }

    public class LevyUser : LoginUser { }

    public class NonLevyUser : LoginUser { }

    public class EoiUser : LoginUser { }

    public class LoggedInUser : LoginUser { }
}
