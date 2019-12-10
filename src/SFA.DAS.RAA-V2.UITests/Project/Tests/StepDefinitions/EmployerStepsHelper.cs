using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.StepDefinitions
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        internal void CreateANewVacancy()
        {
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
                .SubmitVacancy();
        }

    }
}
