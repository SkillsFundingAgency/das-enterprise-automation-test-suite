using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RAALinksSteps
    {
        private readonly ScenarioContext _context;
        private readonly RAAStepsHelper _raaStepsHelper;

        public RAALinksSteps(ScenarioContext context)
        {
            _context = context;
            _raaStepsHelper = new RAAStepsHelper(context);
        }
        
        [Then(@"the Provider is able to search and select a Candidate")]
        public void ThenTheProviderIsAbleToSearchAndSelectACandidate() => _raaStepsHelper.SelectACandidate();


        [Then(@"the Candidate is removed from the Recruit")]
        public void ThenTheCandidateIsRemovedFromTheRecruit() => _raaStepsHelper.SearchForDeletedCandidate();

        [Then(@"the Candidate details is updated in Recruit '(EmailId|PhoneNumber)'")]
        public void ThenTheCandidateDetailsIsUpdatedInRecruit(string changedField) => _raaStepsHelper.VerifyCandidateUpdatedDetails(changedField);
        
        [Then(@"the provider can reach Provider Users")]
        public void ThenTheProviderCanReachProviderUsers()
        {
            _raaStepsHelper.GoToRAAHomePage(false)
                           .AdministratorFunctions()
                           .ProviderUsers();
        }

        [Then(@"the provider can reach Change Ukprn")]
        public void ThenTheProviderCanReachChangeUkprn()
        {
            _raaStepsHelper.GoToRAAHomePage(false)
                           .AdministratorFunctions()
                           .ChangeUkprn();
        }

        [Then(@"the provider can reach Reset Ukprn")]
        public void ThenTheProviderCanReachResetUkprn()
        {
            _raaStepsHelper.GoToRAAHomePage(false)
                           .AdministratorFunctions()
                           .ResetUkprn();
        }

        [Then(@"the provider can reach Transfer Vacancies")]
        public void ThenTheProviderCanReachTransferVacancies()
        {
            _raaStepsHelper.GoToRAAHomePage(false)
                           .AdministratorFunctions()
                           .TransferVacancies();
        }

        [Then(@"the provider can reach Set Vacancy Hours and Wage Type")]
        public void ThenTheProviderCanReachSetVacancyHoursAndWageType()
        {
            _raaStepsHelper.GoToRAAHomePage(false)
                           .AdministratorFunctions()
                           .SetVacancyHoursAndWageType();
        }
    }
}
