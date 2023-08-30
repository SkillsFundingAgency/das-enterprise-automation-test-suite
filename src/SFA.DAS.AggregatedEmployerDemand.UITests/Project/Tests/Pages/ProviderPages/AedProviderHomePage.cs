using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

public class AedProviderHomePage : ProviderHomePage
{
    protected static By FindingEmployersThatNeedATrainingProviderLink => By.LinkText("Find employers that need a training provider");

    public AedProviderHomePage(ScenarioContext context) : base(context) => VerifyPage();

    public FindEmployersThatNeedATrainingProviderPage FindEmployersThatNeedATrainingProvider()
    {
        formCompletionHelper.ClickElement(FindingEmployersThatNeedATrainingProviderLink);
        
        ClickIfPirenIsDisplayed();
        
        return new FindEmployersThatNeedATrainingProviderPage(context);
    }
}
