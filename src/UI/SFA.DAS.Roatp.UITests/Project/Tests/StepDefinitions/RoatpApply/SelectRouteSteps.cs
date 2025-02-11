using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class SelectRouteSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly SelectRouteStepsHelper _selectRouteStepsHelper = new(context);
        private AlreadyOnRoatpPage _alreadyOnRoatpPage;
        private ApplicationOverviewPage _applicationOverviewPage;

        [Then(@"the provider should be able to change the ukprn")]
        public void ThenTheProviderShouldBeAbleToChangeTheUkprn()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(context)
             .Access_ChangeUkprn()
             .SelectNoToChangeUkprnAndContinue();

            YourOrganisation_Section1_Helper.VerifySection1Status(_applicationOverviewPage);

            var page = _applicationOverviewPage
                .Access_ChangeUkprn()
                .SelectYesToChangeUkprnAndContinue()
                .EnterOrgTypeCompanyProvidersUkprn(_objectContext.GetNewUkprn()).ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain();

            SelectRouteStepsHelper.AcceptAndContinue(page);
        }

        [Then(@"the  provider should be able to change route to Employer")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToEmployer()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(context)
            .Access_ChangeRoute()
            .SelectYesToChangeRouteAndContinue()
            .SelectApplicationRouteAsEmployer()
            .SelectYesForLevyPayingEmployerAndContinue()
            .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to change route to Supporting")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToSupporting()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(context)
            .Access_ChangeRoute()
            .SelectYesToChangeRouteAndContinue()
            .SelectApplicationRouteAsSupporting()
            .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to change route to Main")]
        public void ThenTheProviderShouldBeAbleToChangeRouteToMain()
        {
            _applicationOverviewPage = new ApplicationOverviewPage(context)
           .Access_ChangeRoute()
           .SelectYesToChangeRouteAndContinue()
           .SelectApplicationRouteAsMain()
           .AcceptTermAndConditionsAndContinue();
        }

        [Then(@"the provider should be able to verify the Employer route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheEmployerRouteFlow() => _applicationOverviewPage = RoatpApplyEnd2EndStepsHelper.VerifyAnswers_ChangeRouteMainToEmployer(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Supporting route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheSupportingRouteFlow() => _applicationOverviewPage = RoatpApplyEnd2EndStepsHelper.VerifyAnswers_ChangeRouteEmployerToSupporting(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Main route flow")]
        public void ThenTheProviderShouldBeAbleToVerifyTheMainRouteFlow() => _applicationOverviewPage = RoatpApplyEnd2EndStepsHelper.VerifyAnswers_ChangeRouteSupportingToMain(_applicationOverviewPage);

        [Then(@"the provider should be able to verify the Main route flow for route changed Employer To Main")]
        public void ThenTheProviderShouldBeAbleToVerifyTheMainRouteFlowForRouteChangedEmployerToMain() => _applicationOverviewPage = RoatpApplyEnd2EndStepsHelper.VerifyAnswers_ChangeRouteEmployerToMain(_applicationOverviewPage);

        [Given(@"the provider initates an application as employer who is already on Roatp as employer")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerWhoIsAlreadyOnRoatpAsEmployer() => _alreadyOnRoatpPage = _selectRouteStepsHelper.CompleteProviderCharityRouteWhoisAlreayOnRoatp();


        [Then(@"the provider can change the route as main provider")]
        public void ThenTheProviderCanChangeTheRouteAsMainProvider() => _alreadyOnRoatpPage.SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsMain().AcceptTermAndConditionsAndContinue();

    }
}
