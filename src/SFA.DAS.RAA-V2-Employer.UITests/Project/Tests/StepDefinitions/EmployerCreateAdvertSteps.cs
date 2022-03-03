using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateAdvertSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerCreateAdvertStepsHelper _employerCreateVacancyStepsHelper;

        public EmployerCreateAdvertSteps(ScenarioContext context)
        {
            _context = context;
            _employerCreateVacancyStepsHelper = new EmployerCreateAdvertStepsHelper(context);
        }

        [Given(@"the Employer clones and creates an advert")]
        public void TheEmployerClonesAndCreatesAnAdvert() => _employerCreateVacancyStepsHelper.CloneAnAdvert();



        [Given(@"the Employer creates an advert by selecting different work location")]
        public void TheEmployerCreatesAnAdvertBySelectingDifferentWorkLocation() => _employerCreateVacancyStepsHelper.CreateANewAdvert("legal-entity-name", false);

        [Given(@"the Employer creates an anonymous advert")]
        public void TheEmployerCreatesAnAnonymousAdvert() => _employerCreateVacancyStepsHelper.CreateANewAdvert("anonymous", true);

        [Given(@"the Employer creates an advert by using a registered name")]
        public void TheEmployerCreatesAnanAdvertByUsingARegisteredName() => _employerCreateVacancyStepsHelper.CreateANewAdvert("legal-entity-name", true);

        [Given(@"the Employer creates an advert by using a trading name")]
        public void TheEmployerCreatesAnAdvertByUsingATradingName() => _employerCreateVacancyStepsHelper.CreateANewAdvert("existing-trading-name", true);
    }
}
