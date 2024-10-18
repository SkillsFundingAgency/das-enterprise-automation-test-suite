using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions;

[Binding]
public class RatProviderSteps(ScenarioContext context)
{
    private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper = new(context);

    [Then(@"a provider responds to the employer request")]
    public void AProviderRespondsToTheEmployerRequest()
    {
        var providerConfig = context.GetProviderConfig<ProviderConfig>();

        _providerHomePageStepsHelper.GoToProviderHomePage(providerConfig, true);

        var dataHelper = context.Get<RatDataHelper>();

        dataHelper.ProviderEmail = providerConfig.Username;

        dataHelper.ProviderName = providerConfig.Name;

        new RatProviderHomePage(context).NavigateToEmployerRequestPage().SelectStandard().SelectRequest().SelectEmail().SelectPhoneNumber().SubmitAnswers();
    }
}
