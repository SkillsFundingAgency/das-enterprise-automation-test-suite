using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.Framework;
using SFA.DAS.ProviderLogin.Service.Helpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AEDProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
        private readonly string _providerUrl;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;



        public AEDProviderSteps(ScenarioContext context)
        {
            _config = context.GetProviderConfig<ProviderConfig>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);
            _providerUrl = UrlConfig.Provider_BaseUrl;
            _login = new ProviderLoginUser { Username = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Given(@"the provider navigates to Find employers that need a training provider")]
        public void GivenTheProviderNavigatesToFindEmployersThatNeedATrainingProvider()
        {
            _providerStepsHelper.GoToProviderHomePagePage(_login, true)
                .FindEmployersThatNeedATrainingProvider();
        }

        [When(@"the provider shows the which employers they are interested in")]
        public void WhenTheProviderShowsTheWhichEmployersTheyAreInterestedIn()
        {
            _providerStepsHelper.GoToWhichEmployersAreYouInterestedInPage()
                .CheckAndContinueWithfirstEmployerCheckbox();
        }

        [When(@"the provider is able to enter their details '(.*)', '(.*)' and '(.*)'")]
        public void WhenTheProviderIsAbleToEnterTheirDetailsAnd(string emailAddress, string telephoneNumber, string website)
        {
            _providerStepsHelper.ConfirmAndShareProvidersDetailsWithEmployersContactDetails(emailAddress, telephoneNumber, website);
        }
    }
}
