using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class SelectRouteSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly SelectRouteStepsHelper _selectRouteStepsHelper;
        private AlreadyOnRoatpPage _alreadyOnRoatpPage;
        private ApplicationOverviewPage _applicationOverviewPage;
        private readonly YourOrganisation_Section1_Helper _section1_Helper;
        private readonly RoatpApplyEnd2EndStepsHelper _end2EndStepsHelper;

        public SelectRouteSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _selectRouteStepsHelper = new SelectRouteStepsHelper(_context);
            _section1_Helper = new YourOrganisation_Section1_Helper();
            _end2EndStepsHelper = new RoatpApplyEnd2EndStepsHelper();
        }

        [Then(@"the provider should be able to change the ukprn")]
        public void ThenTheProviderShouldBeAbleToChangeTheUkprn()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(_context)
             .Access_ChangeUkprn()
             .SelectNoToChangeUkprnAndContinue();

            _section1_Helper.VerifySection1Status(_applicationOverviewPage);

            var page = _applicationOverviewPage
                .Access_ChangeUkprn()
                .SelectYesToChangeUkprnAndContinue()
                .EnterOrgTypeCompanyProvidersUkprn(_objectContext.GetNewUkprn()).ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain();

            _selectRouteStepsHelper.AcceptAndContinue(page);
        }

        [Then(@"the  provider should be able to change route to Employer")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToEmployer()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(_context)
            .Access_ChangeRoute()
            .SelectYesToChangeRouteAndContinue()
            .SelectApplicationRouteAsEmployer()
            .SelectYesForLevyPayingEmployerAndContinue()
            .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to change route to Supporting")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToSupporting()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(_context)
            .Access_ChangeRoute()
            .SelectYesToChangeRouteAndContinue()
            .SelectApplicationRouteAsSupporting()
            .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to change route to Main")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToMain()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(_context)
           .Access_ChangeRoute()
           .SelectYesToChangeRouteAndContinue()
           .SelectApplicationRouteAsMain()
           .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to verify the Employer route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheEmployerRouteFlow() => _applicationOverviewPage = _end2EndStepsHelper.VerifyAnswers_ChangeRouteMainToEmployer(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Supporting route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheSupportingRouteFlow() => _applicationOverviewPage = _end2EndStepsHelper.VerifyAnswers_ChangeRouteEmployerToSupporting(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Main route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheMainRouteFlow() => _applicationOverviewPage = _end2EndStepsHelper.VerifyAnswers_ChangeRouteSupportingToMain(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Main route flow for route changed Employer To Main")]
        public void ThenTheProviderShouldBeAbleToVerifyTheMainRouteFlowForRouteChangedEmployerToMain() => _applicationOverviewPage = _end2EndStepsHelper.VerifyAnswers_ChangeRouteEmployerToMain(_applicationOverviewPage);

        [Given(@"the provider initates an application as employer who is already on Roatp as employer")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerWhoIsAlreadyOnRoatpAsEmployer() => _alreadyOnRoatpPage = _selectRouteStepsHelper.CompleteProviderCharityRouteWhoisAlreayOnRoatp();

        [Then(@"the provider can change the route as main provider")]
        public void ThenTheProviderCanChangeTheRouteAsMainProvider() => _alreadyOnRoatpPage.SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsMain().AcceptTermAndConditionsAndContinue();
    }
}
