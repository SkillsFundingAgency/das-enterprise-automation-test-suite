using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerPerfTestDataPreparationSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerCreateAdvertPrefStepsHelper _employerCreateAdvertPrefStepsHelper;

        public EmployerPerfTestDataPreparationSteps(ScenarioContext context)
        {
            _context = context;

            _employerCreateAdvertPrefStepsHelper = new EmployerCreateAdvertPrefStepsHelper(context);
        }

        [Given(@"the Employer creates first draft advert using '(.*)'")]
        public void GivenTheEmployerCreatesFirstDraftAdvertUsing(string email)
        {
            var _config = _context.GetRegistrationConfig<RegistrationConfig>();

            var legalEntities = _context.GetAccountLegalEntities(new List<string>() { email });

            var rAAV2EmployerUser = new RAAV2EmployerUser { Username = email, Password = _config.RE_AccountPassword, LegalEntities = legalEntities[0] };

            var page = _employerCreateAdvertPrefStepsHelper.GoToCreateAnApprenticeshipAdvertPage(rAAV2EmployerUser);

            _employerCreateAdvertPrefStepsHelper.CreateFirstDraftAdvert_PrefTest(page);
        }
    }
}
