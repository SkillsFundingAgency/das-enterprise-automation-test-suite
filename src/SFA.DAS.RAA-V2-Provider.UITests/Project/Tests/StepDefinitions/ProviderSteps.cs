using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage();

            new RecruitmentProviderHomePage(_context)
                .RecruitApprentices()
                .CreateVacancy()
                .SelectEmployer();
        }
    }
}
