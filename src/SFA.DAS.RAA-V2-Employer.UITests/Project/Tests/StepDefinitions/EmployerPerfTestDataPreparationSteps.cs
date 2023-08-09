using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerPerfTestDataPreparationSteps
    {
        private readonly ScenarioContext _context;

        public EmployerPerfTestDataPreparationSteps(ScenarioContext context) => _context = context;

        [Given(@"the Employer creates additional using '(.*)'")]
        public void GivenTheEmployerCreatesAdditionalUsing(string email) => GetEmployerCreateAdvertPrefStepsHelper(email).CreateANewAdvert();

        [Given(@"the Employer creates first draft advert using '(.*)'")]
        public void GivenTheEmployerCreatesFirstDraftAdvertUsing(string email)
        {
            var _employerCreateAdvertPrefStepsHelper = GetEmployerCreateAdvertPrefStepsHelper(email);

            var page = _employerCreateAdvertPrefStepsHelper.GoToCreateAnApprenticeshipAdvertPage();

            _employerCreateAdvertPrefStepsHelper.CreateFirstDraftAdvert_PrefTest(page);
        }

        [Given(@"the Employer '([^']*)' grants permission to a provider")]
        public void GivenTheEmployerGrantsPermissionToAProvider(string email, Table table)
        {
            new EmployerPortalLoginHelper(_context).Login(GetRaav2EmployerUser(email), true);

            foreach (var row in table.Rows) new EmployerPermissionsStepsHelper(_context).SetRecruitApprenticesPermission(row[0], row[1]);
        }

        private EmployerCreateAdvertPrefStepsHelper GetEmployerCreateAdvertPrefStepsHelper(string email)
            => new(_context, GetRaav2EmployerUser(email));

        private RAAV2EmployerUser GetRaav2EmployerUser(string email)
        {
            var legalEntities = _context.GetAccountLegalEntities(new List<string>() { email });

            return new RAAV2EmployerUser { Username = email, IdOrUserRef = legalEntities[0].idOrUserRef, LegalEntities = legalEntities[0].listoflegalEntities };
        }
    }
}