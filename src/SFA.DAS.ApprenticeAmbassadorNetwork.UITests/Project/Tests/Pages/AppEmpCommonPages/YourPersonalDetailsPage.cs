namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class YourPersonalDetailsPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your personal details";
    private static By Jobtitle => By.Id("job-title"); 
    private static By JobtitleCheckbox => By.Id("ShowJobTitle");
    private static By BiographyCheckbox => By.Id("ShowBiography");
    private static By Biography => By.Id("biography"); 

    public YourAmbassadorProfilePage ChangePersonalDetailsAndContinue()
    {
        formCompletionHelper.EnterText(Jobtitle, RandomDataGenerator.GenerateRandomAlphabeticString(12));
        formCompletionHelper.EnterText(Biography, RandomDataGenerator.GenerateRandomAlphabeticString(50));
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
    public YourAmbassadorProfilePage HideJobtitleAndBiography()
    {
        formCompletionHelper.UnSelectCheckbox(JobtitleCheckbox);
        formCompletionHelper.UnSelectCheckbox(BiographyCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
    public YourAmbassadorProfilePage DisplayJobtitleAndBiography()
    {
        formCompletionHelper.SelectCheckbox(JobtitleCheckbox);
        formCompletionHelper.SelectCheckbox(BiographyCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
}
