using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateAdvertSteps
    {
        private readonly EmployerCreateAdvertStepsHelper _employerCreateVacancyStepsHelper;

        private CreateAnApprenticeshipAdvertOrVacancyPage _createAnApprenticeshipAdvertPage;

        public EmployerCreateAdvertSteps(ScenarioContext context) => _employerCreateVacancyStepsHelper = new EmployerCreateAdvertStepsHelper(context);

        [Given(@"the Employer can create an advert by entering all the Optional fields")]
        public void TheEmployerCanCreateAnAdvertByEnteringAllTheOptionalFields()
        {
            _employerCreateVacancyStepsHelper.optionalFields = true;
            
            _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.Anonymous);
        }

        [When(@"the Employer creates first submitted advert")]
        public void TheEmployerCreatesFirstSubmittedAdvert() => _employerCreateVacancyStepsHelper.CreateFirstAdvertAndSubmit(_createAnApprenticeshipAdvertPage);

        [Given(@"the employer continue to add advert in the Recruitment")]
        public void TheEmployerContinueToAddAdvertInTheRecruitment() => _createAnApprenticeshipAdvertPage = _employerCreateVacancyStepsHelper.AddAnAdvert();

        [When(@"Employer selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void EmployerSelectsInTheFirstPartOfTheJourney(string wageType) => _employerCreateVacancyStepsHelper.CreateANewAdvert_WageType(wageType);

        [Given(@"the Employer creates an offline advert with disability confidence")]
        public void TheEmployerCreatesAnOfflineAdvertWithDisabilityConfidence() => _employerCreateVacancyStepsHelper.CreateOfflineVacancy();

        [Given(@"the Employer clones and creates an advert")]
        public void TheEmployerClonesAndCreatesAnAdvert() => _employerCreateVacancyStepsHelper.CloneAnAdvert();

        [Given(@"the Employer creates an advert by selecting different work location")]
        public void TheEmployerCreatesAnAdvertBySelectingDifferentWorkLocation() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.LegalEntityName, false);

        [Given(@"the Employer creates an anonymous advert")]
        public void TheEmployerCreatesAnAnonymousAdvert() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.Anonymous);

        [Given(@"the Employer creates an advert by using a registered name")]
        public void TheEmployerCreatesAnanAdvertByUsingARegisteredName() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.LegalEntityName);

        [Given(@"the Employer creates an advert by using a trading name")]
        public void TheEmployerCreatesAnAdvertByUsingATradingName() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.ExistingTradingName);
    }
}
