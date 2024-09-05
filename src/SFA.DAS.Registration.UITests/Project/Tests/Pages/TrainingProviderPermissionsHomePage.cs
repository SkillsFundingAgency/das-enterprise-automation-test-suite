using OpenQA.Selenium;
using TechTalk.SpecFlow;
using YourTrainingProvidersPage_EPR = SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships.YourTrainingProvidersPage;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YourTrainingProvidersLinkHomePage(ScenarioContext context) : HomePage(context)
{
    private static By YourTrainingProvidersLink => By.LinkText("Your training providers");

    public YourTrainingProvidersPage_EPR OpenRelationshipPermissions()
    {
        formCompletionHelper.ClickElement(YourTrainingProvidersLink);
        return new YourTrainingProvidersPage_EPR(context);
    }
}

