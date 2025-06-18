using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Helpers
{
    public class RAAEmployerLoginStepsHelper(ScenarioContext context)
    {
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper = new(context);

        internal HomePage GotoEmployerHomePage() => _homePageStepsHelper.GotoEmployerHomePage();

        internal HomePage GoToHomePage(EasAccountUser loginUser) => _homePageStepsHelper.Login(loginUser);

        internal CreateAnAdvertHomePage GoToCreateAnAdvertHomePage(RAAEmployerUser user)
        {
            GoToHomePage(user);

            _ = new InterimCreateAnAdvertHomePage(context);

            return new CreateAnAdvertHomePage(context);
        }

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage(RAAEmployerUser user)
        {
            GoToHomePage(user);

            return NavigateToRecruitmentHomePage();
        }

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => GoToRecruitmentHomePage(context.GetUser<RAAEmployerUser>());

        internal YourApprenticeshipAdvertsHomePage NavigateToRecruitmentHomePage() => new(context, true);
    }
}
