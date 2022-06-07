namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public abstract class ApprenticeshipTrainingCourseBasePage : FATV2BasePage
{
    protected override string PageTitle => "Apprenticeship training courses";

    protected override bool TakeFullScreenShot => false;

    public ApprenticeshipTrainingCourseBasePage(ScenarioContext context) : base(context) 
    {
        var environmentName = EnvironmentName.ToLower() + "-";

        var currentURL = GetUrl();

        if (!currentURL.ToLower().Contains(environmentName))
        {
            var newURL = currentURL.Insert(8, environmentName);
            
            tabHelper.GoToUrl(newURL);
        }
    }
}
