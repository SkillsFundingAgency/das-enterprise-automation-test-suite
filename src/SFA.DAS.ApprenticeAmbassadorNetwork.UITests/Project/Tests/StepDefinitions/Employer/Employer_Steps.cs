using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;

[Binding, Scope(Tag = "@aanemployer")]
public class Employer_Steps(ScenarioContext context) : Employer_BaseSteps(context)
{
    private EventsHubPage eventsHubPage;

    private SearchNetworkEventsPage searchNetworkEventsPage;
    private NetworkDirectoryPage networkDirectoryPage;
    private AanEmployerOnBoardedUser user;

    [Given(@"an onboarded employer logs into the AAN portal")]
    public void GivenAnOnboardedEmployerLogsIntoTheAANPortal()
    {
        EmployerSign(user = context.GetUser<AanEmployerOnBoardedUser>());

        networkHubPage = new Employer_NetworkHubPage(context);
    }

    [Then(@"the user should be able to successfully verify ambassador profile")]
    public void TheUserShouldBeAbleToSuccessfullyVerifyAmbassadorProfile()
    {
        networkHubPage.AccessProfileSettings().AccessYourAmbassadorProfile().VerifyYourAmbassadorProfile(user.Username);
    }

    [Then(@"the user should be able to successfully signup for a future event")]
    public void SignupForAFutureEvent() => eventsHubPage = SignupForAFutureEvent(networkHubPage, user.Username);

    [Then(@"the user should be able to successfully Cancel the attendance for a signed up event")]
    public void CancelTheAttendance() => CancelTheAttendance(eventsHubPage);

    [Then(@"the user should be able to successfully filter events by date")]
    public void FilterByDate() => searchNetworkEventsPage = FilterByDate(networkHubPage);

    [Then(@"the user should be able to successfully filter events by event format")]
    public void FilterByEventFormat() => FilterByEventFormat(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by event type")]
    public void FilterByEventType() => FilterByEventType(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by regions")]
    public void FilterByEventRegion() => FilterByEventRegion(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by multiple combination of filters")]
    public void FilterByMultipleCombination() => FilterByMultipleCombination(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by role Network Directory")]
    public void FilterByRole_NetworkDirectory() => networkDirectoryPage = FilterByEventRoleNetworkDirectory(networkHubPage);

    [Then(@"the user should be able to successfully filter events by regions Network Directory")]
    public void FilterByEventRegion_NetworkDirectory() => FilterByEventRegionNetworkDirectory(networkDirectoryPage);

    [Then(@"the user should be able to successfully filter events by multiple combination of filters Network Directory")]
    public void FilterByMultipleCombination_NetworkDirectory() => FilterByMultipleCombinationNetworkDirectory(networkDirectoryPage);
}
