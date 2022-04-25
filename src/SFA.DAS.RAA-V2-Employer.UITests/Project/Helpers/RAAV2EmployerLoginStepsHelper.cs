using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class RAAV2EmployerLoginStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;

        public RAAV2EmployerLoginStepsHelper(ScenarioContext context)
        {
            _context = context;
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
        }

        internal HomePage GotoEmployerHomePage() => _homePageStepsHelper.GotoEmployerHomePage();

        internal HomePage GoToHomePage(EasAccountUser loginUser) => _homePageStepsHelper.Login(loginUser);

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage()
        {
            GoToHomePage(_context.GetUser<RAAV2EmployerUser>());

            return NavigateToRecruitmentHomePage();
        }

        internal YourApprenticeshipAdvertsHomePage NavigateToRecruitmentHomePage() => new YourApprenticeshipAdvertsHomePage(_context, true);
    }
}
