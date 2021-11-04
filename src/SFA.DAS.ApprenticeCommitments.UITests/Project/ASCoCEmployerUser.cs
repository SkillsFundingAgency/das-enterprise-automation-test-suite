using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project
{
    public class ASCoCEmployerUser : LoginUser
    {
        public CocApprenticeUser CocApprenticeUser { get; set; }
    }

    public class CocApprenticeUser : ApprenticeUser { }

    public abstract class ApprenticeUser
    {
        public string ApprenticeUsername { get; set; }

        public string ApprenticePassword { get; set; }
    }
}
