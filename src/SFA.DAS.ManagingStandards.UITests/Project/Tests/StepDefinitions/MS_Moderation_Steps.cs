using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class MS_Moderation_Steps(ScenarioContext context)
{
    private Moderation_ProviderDetailsPage _moderation_ProviderDetailsPage;
    private Moderation_UpdateProviderPage _moderation_UpdateProviderPage;

    [Given(@"the tribal user searches for provider with UKPRN")]
    public void GivenTheTribalUserSearchesForProviderWithUKPRN()
    {
        new DfeAdminLoginStepsHelper(context).NavigateAndLoginToASAdmin();

        _moderation_ProviderDetailsPage = new Moderation_HomePage(context).SearchForTrainingProvider().SearchTrainingProviderByUkprn(MS_DataHelper.UKPRN);
    }

    [When(@"the tribal user chooses to change the provider details")]
    public void WhenTheTribalUserChoosesToChangeTheProviderDetails()
    {
        _moderation_UpdateProviderPage = _moderation_ProviderDetailsPage.ChangeProviderDetail();
    }

    [Then(@"the tribal user is allowed to make the change")]
    public void ThenTheTribalUserIsAllowedToMakeTheChange()
    {
        _moderation_UpdateProviderPage.EnterUpdateDescriptionAndContinue()
            .ContinueOnCheckProviderUpdatePage()
            .ChangeProviderDetail()
            .VerifyUpdateDescriptionText();
    }
}
