using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerPerfTestDataPreparationSteps
    {
        private readonly ScenarioContext _context;

        public EmployerPerfTestDataPreparationSteps(ScenarioContext context) => _context = context;


        [Given(@"the Employer creates first draft advert using '(.*)'")]
        public void GivenTheEmployerCreatesFirstDraftAdvertUsing(string email)
        {
            var _employerCreateAdvertPrefStepsHelper = new EmployerCreateAdvertPrefStepsHelper(_context);

            var page = _employerCreateAdvertPrefStepsHelper.GoToCreateAnApprenticeshipAdvertPage(GetRaav2EmployerUser(email));

            _employerCreateAdvertPrefStepsHelper.CreateFirstDraftAdvert_PrefTest(page);
        }

        [Given(@"the Employer '([^']*)' grants permission to a provider")]
        public void GivenTheEmployerGrantsPermissionToAProvider(string email, Table table)
        {
            new EmployerPortalLoginHelper(_context).Login(GetRaav2EmployerUser(email), true);

            foreach (var row in table.Rows)
            {
                new EmployerPermissionsStepsHelper(_context).SetRecruitApprenticesPermission(row[0], row[1]);
            }
        }

        private RAAV2EmployerUser GetRaav2EmployerUser(string email)
        {
            var _config = _context.GetRegistrationConfig<RegistrationConfig>();

            var legalEntities = _context.GetAccountLegalEntities(new List<string>() { email });

            return new RAAV2EmployerUser { Username = email, Password = _config.RE_AccountPassword, LegalEntities = legalEntities[0] };
        }
    }
}