namespace SFA.DAS.Live.SmokeTests.Project.Tests.Steps;

[Binding]
public class ApprovalsNavigationSteps(ScenarioContext context)
{
    private ApprenticesHomePage _apprenticesHomePage;

    [When(@"employer navigates to Apprentices tab in the nav bar")]
    public void EmployerNavigatesToApprenticesTabInTheNavBar()
    {
        _ = new LiveHomePage(context);

        _apprenticesHomePage = new ApprenticesHomePage(context);
    }

    [Then(@"Add an apprentice link should direct user to Add an apprentice page")]
    public void AddAnApprenticeLinkShouldDirectUserToAddAnApprenticePage()
    {
        _apprenticesHomePage = _apprenticesHomePage.AddAnApprentice().GoBackToApprenticesHomePage();
    }

    [Then(@"Apprentice requests link should direct user to Apprentice requests page")]
    public void ApprenticeRequestsLinkShouldDirectUserToApprenticeRequestsPage()
    {
        _apprenticesHomePage = _apprenticesHomePage.ClickApprenticeRequestsLink().GoBackToApprenticesHomePage();
    }

    [Then(@"Manage your apprentices link should direct user to Manage your apprentices page")]
    public void ManageYourApprenticesLinkShouldDirectUserToManageYourApprenticesPage()
    {
        _apprenticesHomePage = _apprenticesHomePage.ClickManageYourApprenticesLink().GoBackToApprenticesHomePage();
    }
}
