using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateAdvertSteps
    {
        private readonly ScenarioContext _context;

        private readonly EmployerCreateAdvertStepsHelper _employerCreateVacancyStepsHelper;

        private YourApprenticeshipAdvertsHomePage _yourApprenticeshipAdvertsHomePage;

        private CreateAnApprenticeshipAdvertPage _createAnApprenticeshipAdvertPage;

        public EmployerCreateAdvertSteps(ScenarioContext context)
        {
            _context = context;
            _employerCreateVacancyStepsHelper = new EmployerCreateAdvertStepsHelper(context);
        }

        [Then(@"the Employer can open the draft and submits the advert")]
        public void TheEmployerCanOpenTheDraftAndSubmitsTheAdvert() => _employerCreateVacancyStepsHelper.SubmitDraftAdvert(GoToYourAdvertFromDraftAdverts());

        [Given(@"the Employer creates Draft advert")]
        public void TheEmployerCreatesDraftAdvert() => ReturnToApplications(_employerCreateVacancyStepsHelper.CreateDraftAdvert());

        [When(@"the Employer completes the Draft advert to cancel deleting the draft")]
        public void TheEmployerCreatesCompleteDraftAdvert() => _employerCreateVacancyStepsHelper.CompleteDraftAdvert(GoToYourAdvertFromDraftAdverts());

        [Given(@"the Employer can create an advert by entering all the Optional fields")]
        public void TheEmployerCanCreateAnAdvertByEnteringAllTheOptionalFields()
        {
            _employerCreateVacancyStepsHelper.optionalFields = true;
            
            _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAV2Const.Anonymous);
        }

        [When(@"the Employer creates first submitted advert")]
        public void TheEmployerCreatesFirstSubmittedAdvert() => _employerCreateVacancyStepsHelper.CreateFirstAdvertAndSubmit(_createAnApprenticeshipAdvertPage);

        [When(@"the Employer creates first Draft advert")]
        public void TheEmployerCreatesFirstDraftAdvert() => CreateDraftAdvert(_createAnApprenticeshipAdvertPage, true);

        [Given(@"the employer continue to add advert in the Recruitment")]
        public void TheEmployerContinueToAddAdvertInTheRecruitment() => _createAnApprenticeshipAdvertPage = _employerCreateVacancyStepsHelper.AddAnAdvert();

        [When(@"Employer selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void EmployerSelectsInTheFirstPartOfTheJourney(string wageType) => _employerCreateVacancyStepsHelper.CreateANewAdvert_WageType(wageType);

        [Given(@"the Employer creates an offline advert with disability confidence")]
        public void TheEmployerCreatesAnOfflineAdvertWithDisabilityConfidence() => _employerCreateVacancyStepsHelper.CreateOfflineVacancy();

        [When(@"Employer cancels after saving the title of the advert")]
        public void EmployerCancelsAfterSavingTheTitleOfTheAdvert() => _yourApprenticeshipAdvertsHomePage = _employerCreateVacancyStepsHelper.CancelAdvert();

        [Then(@"the advert is saved as a draft")]
        public void ThenTheVacancyIsSavedAsADraft() => GoToYourAdvertFromDraftAdverts();

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

        private void CreateDraftAdvert(CreateAnApprenticeshipAdvertPage page, bool createFirstDraftAdvert)
        {
            page = _employerCreateVacancyStepsHelper.CreateDraftAdvert(page, createFirstDraftAdvert);

            ReturnToApplications(page);
        }

        private void ReturnToApplications(CreateAnApprenticeshipAdvertPage page) { page.ReturnToApplications(); _yourApprenticeshipAdvertsHomePage = new YourApprenticeshipAdvertsHomePage(_context); }

        private CreateAnApprenticeshipAdvertPage GoToYourAdvertFromDraftAdverts() => _yourApprenticeshipAdvertsHomePage.GoToYourAdvertFromDraftAdverts().CreateAnApprenticeshipAdvertPage();
    }
}
