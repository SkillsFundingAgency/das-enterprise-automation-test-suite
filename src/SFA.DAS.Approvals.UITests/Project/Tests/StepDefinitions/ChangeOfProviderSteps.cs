using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ChangeOfPartyConfig _changeOfPartyConfig;
        private readonly ProviderLoginUser _newProviderLoginDetails;

        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            _newProviderLoginDetails = new ProviderLoginUser { Username = _changeOfPartyConfig.UserId, Password = _changeOfPartyConfig.Password, Ukprn = _changeOfPartyConfig.Ukprn };
            new RestartWebDriverHelper(context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Approvals");
        }

        [When(@"new provider approves the cohort")]
        public void WhenNewProviderApprovesTheCohort()
        {
            //ProviderLoginUser _newProviderLoginDetails = new ProviderLoginUser { Username = _changeOfPartyConfig.UserId, Password = _changeOfPartyConfig.Password, Ukprn = _changeOfPartyConfig.Ukprn };
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, false);

            new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprentice()
                .EditCopApprenticeDetails()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        [When(@"employer approves the cohort")]
        public void WhenEmployerApprovesTheCohort()
        {
            new EmployerStepsHelper(_context)
                .Approve();
        }

        [Then(@"a new live apprenticeship record is created with new Provider")]
        public void ThenANewLiveApprenticeshipRecordIsCreatedWithNewProvider()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            new ProviderManageYourApprenticesPage(_context, true)
                .SelectViewCurrentApprenticeDetails();
        }
    }
}
