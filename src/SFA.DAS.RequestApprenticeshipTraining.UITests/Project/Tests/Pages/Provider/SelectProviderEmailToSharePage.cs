namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class SelectProviderEmailToSharePage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Select the email address to share";

    public SelectProviderPhoneToSharePage SelectEmail()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(By.CssSelector($"input[value='{ratDataHelper.ProviderEmail}'][type='radio']")));

        Continue();

        return new(context);
    }
}
