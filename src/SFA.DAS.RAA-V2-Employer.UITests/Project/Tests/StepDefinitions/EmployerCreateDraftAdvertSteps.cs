using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateDraftAdvertSteps(ScenarioContext context)
    {
        private readonly EmployerCreateDraftAdvertStepsHelper _stepsHelper = new(context);

        private YourApprenticeshipAdvertsHomePage _yourApprenticeshipAdvertsHomePage;

        [When(@"the Employer creates first Draft advert")]
        public void TheEmployerCreatesFirstDraftAdvert() => ReturnToApplications(_stepsHelper.CreateFirstDraftAdvert(new CreateAnApprenticeshipAdvertOrVacancyPage(context)));

        [Then(@"the Employer is able to delete the draft vacancy")]
        public void ThenTheEmployerIsAbleToDeleteTheDraftVacancy() => _stepsHelper.CompleteDeleteOfDraftVacancy();

        [When(@"the Employer completes the Draft advert to cancel deleting the draft")]
        public void TheEmployerCreatesCompleteDraftAdvert() => _stepsHelper.CompleteDraftAdvert(GoToYourAdvertFromDraftAdverts());

        [Then(@"the Employer can open the draft and submits the advert")]
        public void TheEmployerCanOpenTheDraftAndSubmitsTheAdvert() => _stepsHelper.SubmitDraftAdvert(GoToYourAdvertFromDraftAdverts());

        [Given(@"the Employer creates Draft advert")]
        public void TheEmployerCreatesDraftAdvert() => ReturnToApplications(_stepsHelper.CreateDraftAdvert());

        [Then(@"the advert is saved as a draft")]
        public void ThenTheVacancyIsSavedAsADraft() => GoToYourAdvertFromDraftAdverts();

        [When(@"Employer cancels after saving the title of the advert")]
        public void EmployerCancelsAfterSavingTheTitleOfTheAdvert() => _yourApprenticeshipAdvertsHomePage = _stepsHelper.CancelAdvert();

        private void ReturnToApplications(CreateAnApprenticeshipAdvertOrVacancyPage page) { page.ReturnToApplications(); _yourApprenticeshipAdvertsHomePage = new YourApprenticeshipAdvertsHomePage(context); }

        private CreateAnApprenticeshipAdvertOrVacancyPage GoToYourAdvertFromDraftAdverts() => _yourApprenticeshipAdvertsHomePage.GoToYourAdvertFromDraftAdverts().CreateAnApprenticeshipAdvertPage();
    }
}
