using System;
using OpenQA.Selenium;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions;


namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AEDProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;


        public AEDProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _config = context.GetProviderConfig<ProviderConfig>();
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
        }

        [Then(@"they are able to register their interest with the employer")]
        public void ThenTheyAreAbleToRegisterTheirInterestWithTheEmployer()
        {
        }

    }
}
