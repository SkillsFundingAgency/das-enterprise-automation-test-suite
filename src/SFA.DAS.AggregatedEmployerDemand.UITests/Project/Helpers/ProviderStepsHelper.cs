using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        private By Change => By.LinkText("Change");

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        internal AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new AedProviderHomePage(_context);
        }

        public WhichEmployersAreYouInterestedInPage GoToWhichEmployersAreYouInterestedInPage()
        {
            new FindEmployersThatNeedATrainingProviderPage(_context).ViewWhichEmployerNeedsATrainingProvider();
            return new WhichEmployersAreYouInterestedInPage(_context);
        }
        public EditProvidersContactDetailsPage GoToEditProvidersContactDetailsPage()
        {
            new WhichEmployersAreYouInterestedInPage(_context).CheckAndContinueWithfirstEmployerCheckbox();
            return new EditProvidersContactDetailsPage(_context);
        }
        public WeveSharedYourContactDetailsWithEmployersPage ConfirmAndShareProvidersDetailsWithEmployersContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            new EditProvidersContactDetailsPage(_context).EnterProviderEmailAddressDetails(emailAddress)
                .EnterProviderTelephoneNumberDetails(telephoneNumber)
                .EnterProviderWebsiteDetails(website)
                .ContinueToConfirmProviderContactDetailsPage()
                .ContinueToProviderCheckYourAnswersPage()
                .ContinueToWeveSharedYourContactDetailsWithEmployersPage();
            return new WeveSharedYourContactDetailsWithEmployersPage(_context);
        }
        public CheckYourAnswersPage ConfirmProviderContactDetailsBeforeSubmitting(string emailAddress, string telephoneNumber, string website)
        {
            new EditProvidersContactDetailsPage(_context).EnterProviderEmailAddressDetails(emailAddress)
               .EnterProviderTelephoneNumberDetails(telephoneNumber)
               .EnterProviderWebsiteDetails(website)
               .ContinueToConfirmProviderContactDetailsPage()
               .ContinueToProviderCheckYourAnswersPage();
            return new CheckYourAnswersPage(_context);
        }
        public ConfirmProvidersContactDetailsPage ConfirmProviderContactDetailsHaveBeenEdited(string newEmailAddress, string newTelephoneNumber, string newWebsite)
        {
            new EditProvidersContactDetailsPage(_context).EnterProviderEmailAddressDetails(newEmailAddress)
               .EnterProviderTelephoneNumberDetails(newTelephoneNumber)
               .EnterProviderWebsiteDetails(newWebsite)
               .ContinueToConfirmProviderContactDetailsPage();
            return new ConfirmProvidersContactDetailsPage(_context);
        }
        public WeveSharedYourContactDetailsWithEmployersPage ConfirmEditedProviderContactDetailsAndSubmit()
        {
            new ConfirmProvidersContactDetailsPage(_context).ContinueToProviderCheckYourAnswersPage()
                .ContinueToWeveSharedYourContactDetailsWithEmployersPage();
            return new WeveSharedYourContactDetailsWithEmployersPage(_context);
        }
        public EditProvidersContactDetailsPage ChangeProviderContactDetails()
        {
            new CheckYourAnswersPage(_context).ChangeProviderContactDetails();
            return new EditProvidersContactDetailsPage(_context);
        }
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
            new EditProvidersContactDetailsPage(_context).EnterProviderEmailAddressDetails(wrongEmailAddress)
               .EnterProviderTelephoneNumberDetails(wrongTelephoneNumber)
               .EnterProviderWebsiteDetails(website)
               .ContinueToConfirmProviderContactDetailsPage();
            return new EditProvidersContactDetailsPage(_context);
        }
        public ConfirmProvidersContactDetailsPage ReEnterProviderContactDetailsBeforeResubmitting(string emailAddress, string telephoneNumber, string website)
        {
            new EditProvidersContactDetailsPage(_context).EnterProviderEmailAddressDetails(emailAddress)
               .EnterProviderTelephoneNumberDetails(telephoneNumber)
               .EnterProviderWebsiteDetails(website)
               .ContinueToConfirmProviderContactDetailsPage();
            return new ConfirmProvidersContactDetailsPage(_context);
        }
        public EditProvidersContactDetailsPage AttemptToProgressWithoutEnteringProviderContactDetails()
        {
            new EditProvidersContactDetailsPage(_context).ContinueToConfirmProviderContactDetailsPage();
            return new EditProvidersContactDetailsPage(_context);
        }
        public WhichEmployersAreYouInterestedInPage ChangeProviderLocationDetails()
        {
            new CheckYourAnswersPage(_context).ChangeProviderLocationDetails();
            return new WhichEmployersAreYouInterestedInPage(_context);
        }
        public WeveSharedYourContactDetailsWithEmployersPage ConfirmEditedProviderLocationDetailsAndSubmit()
        {
            new WhichEmployersAreYouInterestedInPage(_context).CheckAndContinueWithfirstEmployerCheckboxAfterChange()
                .ContinueToProviderCheckYourAnswersPage()
                .ContinueToWeveSharedYourContactDetailsWithEmployersPage();
            return new WeveSharedYourContactDetailsWithEmployersPage(_context);
        }
    }
}