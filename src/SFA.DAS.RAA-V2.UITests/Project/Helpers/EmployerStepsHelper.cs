using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;
        private readonly HomePageStepsHelper _homePageStepsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
            _homePageStepsHelper = new HomePageStepsHelper(context);
        }

        internal void ApplicantSucessful()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            new RecruitmentHomePage(_context, true)
                .SearchLiveVacancy()
                .NavigateToManageApplicant()
                .MakeApplicantSucessful()
                .NotifyApplicantSucessful();
        }


        internal void CreateANewVacancy()
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            new RecruitmentHomePage(_context, true)
                .CreateANewVacancy()
                .CreateNewVacancy()
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinue()
                .ChooseTrainingProvider()
                .ConfirmTrainingProviderAndContinue()
                .ChooseNoOfPositions()
                .SelectOrganisation()
                .ChooseRegisteredName()
                .ChooseAddress()
                .EnterImportantDates()
                .EnterDuration("52", "40")
                .SelectNationalMinimumWage()
                .PreviewVacancy()
                .AddBriefOverview()
                .EnterBriefOverview()
                .AddDescription()
                .EnterDescription()
                .AddSkills()
                .SelectSkill()
                .AddQualifications()
                .EnterQualifications()
                .ConfirmQualifications()
                .AddApplicationProcess()
                .ApplicationMethodFAA()
                .AddEmployerDescription()
                .EnterEmployerDescription()
                .SubmitVacancy()
                .SetVacancyReference();
        }
    }
}
