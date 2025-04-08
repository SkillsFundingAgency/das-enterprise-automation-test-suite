using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAAProvider.UITests.Project.Helpers;
using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderCreateVacancySteps(ScenarioContext context)
    {
        private readonly ProviderCreateVacancyStepsHelper _providerStepsHelper = new(context);
        private readonly ProviderCreateDraftAdvertStepsHelper _stepsHelper = new(context);
        private RecruitmentHomePage _recruitmentHomePage;

        [Then(@"the Provider creates anonymous vacancy through View all your vacancies page")]
        public void ThenTheProviderCreatesAnonymousVacancyThroughViewAllYourVacanciesPage() => _providerStepsHelper.CreateAnonymousVacancy();

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => CreateANewVacancy();

        [Given(@"the Provider creates a vacancy with ""(.*)"" work locations by entering all the Optional fields and ""(.*)"" additional questions")]
        public void GivenTheProviderCreatesAVacancyWithWorkLocationsByEnteringAllTheOptionalFields(string locationType, string additionalQuestions)
        {
            _providerStepsHelper.optionalFields = true;

            bool enterQuestion1, enterQuestion2;

            switch (additionalQuestions)
            {
                case "first":
                    enterQuestion1 = true;
                    enterQuestion2 = false;
                    break;
                case "second":
                    enterQuestion1 = false;
                    enterQuestion2 = true;
                    break;
                default:
                    enterQuestion1 = true;
                    enterQuestion2 = true;
                    break;
            }

            _providerStepsHelper.CreateVacancyForLocationTypes(locationType, enterQuestion1, enterQuestion2);
        }

        [When(@"the Provider creates an Offline vacancy")]
        public void WhenTheProviderCreatesAnOfflineVacancy() => _providerStepsHelper.CreateOfflineVacancy();

        [When(@"Provider selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type|Set As Competitive)' in the first part of the journey")]
        public void WhenProviderSelectsInTheFirstPartOfTheJourney(string wageType) => _providerStepsHelper.CreateVacancyForWageType(wageType);

        [Given("Provider cancels after saving the title of the advert")]
        public void ProviderCancelsAfterSavingTheTitleOfTheAdvert() => _recruitmentHomePage = _providerStepsHelper.CancelAdvert();

        [Given(@"the Provider creates Draft advert")]
        public void TheProviderCreatesDraftAdvert() => ReturnToDashoard(_providerStepsHelper.CreateDraftAdvert());

        [When(@"the Provider completes the Draft advert to cancel deleting the draft")]
        public void TheProviderCreatesCompleteDraftAdvert() => _stepsHelper.CompleteDraftAdvert(GoToYourAdvertFromDraftAdverts());

        [Then(@"the Provider is able to delete the draft vacancy")]
        public void ThenTheProviderIsAbleToDeleteTheDraftVacancy() => _stepsHelper.CompleteDeleteOfDraftVacancy();

        [Then(@"the advert is saved as a draft")]
        public void ThenTheVacancyIsSavedAsADraft() => GoToYourAdvertFromDraftAdverts();

        [Then(@"the Provider can open the draft and submits the advert")]
        public void TheProviderCanOpenTheDraftAndSubmitsTheAdvert() => _stepsHelper.SubmitDraftAdvert(GoToYourAdvertFromDraftAdverts());

        private void CreateANewVacancy() => _providerStepsHelper.CreateANewVacancyForRandomEmployer();

        private void ReturnToDashoard(CreateAnApprenticeshipAdvertOrVacancyPage page) { page.ReturnToDashoard(); _recruitmentHomePage = new RecruitmentHomePage(context); }

        private CreateAnApprenticeshipAdvertOrVacancyPage GoToYourAdvertFromDraftAdverts() => _recruitmentHomePage.GoToYourAdvertFromDraftAdverts().CreateAnApprenticeshipAdvertPage();

    }
}
