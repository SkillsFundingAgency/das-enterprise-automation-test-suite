using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YourTrainingProvidersLinkHomePage(ScenarioContext context) : HomePage(context)
{
    private static By YourTrainingProvidersLink => By.LinkText("Your training providers");

    public YourTrainingProvidersPage OpenProviderPermissions()
    {
        formCompletionHelper.ClickElement(YourTrainingProvidersLink);
        return new YourTrainingProvidersPage(context);
    }
}

