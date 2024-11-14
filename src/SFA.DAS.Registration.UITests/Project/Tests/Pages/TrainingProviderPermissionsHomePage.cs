using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class ManageTrainingProvidersLinkHomePage(ScenarioContext context) : HomePage(context)
{
    private static By ManageTrainingProvidersLink => By.LinkText("Manage training providers");

    public ManageTrainingProvidersPage OpenRelationshipPermissions()
    {
        formCompletionHelper.ClickElement(ManageTrainingProvidersLink);

        return new ManageTrainingProvidersPage(context);
    }
}

