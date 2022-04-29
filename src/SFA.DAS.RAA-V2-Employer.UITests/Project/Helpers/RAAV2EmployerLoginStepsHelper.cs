using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
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

        internal CreateAnAdvertHomePage GoToCreateAnAdvertHomePage(RAAV2EmployerUser user)
        {
            GoToHomePage(user);

            new InterimCreateAnAdvertHomePage(_context);

            return new CreateAnAdvertHomePage(_context);
        }

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage(RAAV2EmployerUser user)
        {
            GoToHomePage(user);

            return NavigateToRecruitmentHomePage();
        }

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => GoToRecruitmentHomePage(_context.GetUser<RAAV2EmployerUser>());
        
        internal YourApprenticeshipAdvertsHomePage NavigateToRecruitmentHomePage() => new YourApprenticeshipAdvertsHomePage(_context, true);
    }
}
