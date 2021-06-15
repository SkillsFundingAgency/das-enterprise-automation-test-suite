using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;


namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        public AedProviderHomePage GoToProviderHomePagePage(ProviderLoginUser login, bool newTab = true)
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
    }
}
