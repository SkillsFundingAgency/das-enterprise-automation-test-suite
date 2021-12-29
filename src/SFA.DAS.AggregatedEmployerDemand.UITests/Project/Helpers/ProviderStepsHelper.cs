using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;

        public ProviderStepsHelper(ScenarioContext context) => _context = context;

        internal AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(login, newTab);

            return new AedProviderHomePage(_context);
        }

        public WhichEmployersAreYouInterestedInPage GoToWhichEmployersAreYouInterestedInPage() => new FindEmployersThatNeedATrainingProviderPage(_context).ViewWhichEmployerNeedsATrainingProvider();

        public WeveSharedYourContactDetailsWithEmployersPage ConfirmAndShareProvidersDetailsWithEmployersContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            return ProvidersCheckYourAnswers(emailAddress, telephoneNumber, website).ContinueToWeveSharedYourContactDetailsWithEmployersPage();
        }

        public WeveSharedYourContactDetailsWithEmployersPage ConfirmEditedProviderContactDetailsAndSubmit() => 
            new ConfirmProvidersContactDetailsPage(_context).ContinueToProviderCheckYourAnswersPage().ContinueToWeveSharedYourContactDetailsWithEmployersPage();

        public EditProvidersContactDetailsPage ChangeProviderContactDetails() => new CheckYourAnswersPage(_context).ChangeProviderContactDetails();

        public WhichEmployersAreYouInterestedInPage NavigateBacktoWhichEmployersAreYouInterestedInPageFromCheckYourAnswersPage()
        {
            new CheckYourAnswersPage(_context).BackToProvidersContactDetailsPage()
                .BackToEditProvidersContactDetailsPage()
                .BackToWhichEmployersAreYouInterestedInPage()
                .BackToFindEmployersThatNeedATrainingProviderPage();
            return new WhichEmployersAreYouInterestedInPage(_context);
        }

        public EditProvidersContactDetailsPage EnterIncorrectProviderContactDetailsBeforeResubmitting(string wrongEmailAddress, string wrongTelephoneNumber, string website)
        {
            return EnterProvidersContactDetails(wrongEmailAddress, wrongTelephoneNumber, website).ContinueWithInvalidDetails();
        }

        public EditProvidersContactDetailsPage AttemptToProgressWithoutEnteringProviderContactDetails() => new EditProvidersContactDetailsPage(_context).ContinueWithInvalidDetails();

        public WhichEmployersAreYouInterestedInPage ChangeProviderLocationDetails() => new CheckYourAnswersPage(_context).ChangeProviderLocationDetails();

        public WeveSharedYourContactDetailsWithEmployersPage ConfirmEditedProviderLocationDetailsAndSubmit()
        {
            return new WhichEmployersAreYouInterestedInPage(_context)
                .CheckAndContinueWithfirstEmployerCheckboxAfterChange()
                .ContinueToProviderCheckYourAnswersPage()
                .ContinueToWeveSharedYourContactDetailsWithEmployersPage();
        }

        public ConfirmProvidersContactDetailsPage ConfirmProvidersContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            return EnterProvidersContactDetails(emailAddress, telephoneNumber, website).ContinueToConfirmProviderContactDetailsPage();
        }

        public CheckYourAnswersPage ProvidersCheckYourAnswers(string emailAddress, string telephoneNumber, string website)
        {
            return ConfirmProvidersContactDetails(emailAddress, telephoneNumber, website).ContinueToProviderCheckYourAnswersPage();
        }

        private EditProvidersContactDetailsPage EnterProvidersContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            return new EditProvidersContactDetailsPage(_context).EnterProvidersContactDetails(emailAddress, telephoneNumber, website);
        }
    }
}