using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions;

[Binding]
public class AedProviderSteps
{
    private readonly ProviderStepsHelper _providerStepsHelper;
    private readonly ProviderLoginUser _login;

    private ConfirmProvidersContactDetailsPage confirmProvidersContactDetailsPage;

    public AedProviderSteps(ScenarioContext context)
    {
        _providerStepsHelper = new ProviderStepsHelper(context);
        
        var config = context.GetProviderConfig<ProviderConfig>();
        _login = new ProviderLoginUser { UserId = config.UserId, Password = config.Password, Ukprn = config.Ukprn };
    }

    [Given(@"the provider has provided their contact details")]
    public void GivenTheProviderHasProvidedTheirContactDetails()
    {
        FindEmployersThatNeedATrainingProvider();

        confirmProvidersContactDetailsPage = _providerStepsHelper
            .GoToWhichEmployersAreYouInterestedInPage()
            .CheckAndContinueWithfirstEmployerCheckbox()
            .EnterValidDetails();
    }

    [Then(@"the provider can edit their contact details")]
    public void ThenTheProviderCanEditTheirContactDetails()
    {
        confirmProvidersContactDetailsPage = confirmProvidersContactDetailsPage.ContinueToProviderCheckYourAnswersPage().ChangeProviderContactDetails().EnterValidDetails();

        ProviderStepsHelper.ConfirmEditedProviderContactDetailsAndSubmit(confirmProvidersContactDetailsPage);
    }

    [Then(@"An error is thrown if provider does not enter or enter invalid contact details")]
    public void ThenAnErrorIsThrownIfProviderDoesNotEnterOrEnterInvalidContactDetails()
    {
        FindEmployersThatNeedATrainingProvider();

        confirmProvidersContactDetailsPage = _providerStepsHelper
            .GoToWhichEmployersAreYouInterestedInPage()
            .CheckAndContinueWithfirstEmployerCheckbox()
            .DoNotEnterDetails()
            .EnterInvalidDetails()
            .EnterValidDetails();
    }
    
    [Then(@"the provider is able to submit the edited details")]
    public void ThenTheProviderIsAbleToSubmitTheEditedDetails() => ProviderStepsHelper.ConfirmEditedProviderContactDetailsAndSubmit(confirmProvidersContactDetailsPage);

    [Then(@"the provider is able to navigate to beginning of the journey using the back links")]
    public void ThenTheProviderIsAbleToNavigateToBeginningOfTheJourneyUsingTheBackLinks() => ProviderStepsHelper.NavigateBacktoWhichEmployersAreYouInterestedInPage(confirmProvidersContactDetailsPage);

    [Then(@"the provider is able to submit their location details")]
    public void TheProviderIsAbleToSubmitTheirLocationDetails() => ProviderStepsHelper.SubmitProviderLocationDetails(confirmProvidersContactDetailsPage);

    private FindEmployersThatNeedATrainingProviderPage FindEmployersThatNeedATrainingProvider() => _providerStepsHelper.GoToProviderHomePagePage(_login, true).FindEmployersThatNeedATrainingProvider();

}
