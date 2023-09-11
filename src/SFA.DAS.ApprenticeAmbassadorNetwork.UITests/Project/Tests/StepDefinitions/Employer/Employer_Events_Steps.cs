using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;

[Binding, Scope(Tag = "@aanemployer")]
public class Employer_Events_Steps : Employer_BaseSteps
{
    public Employer_Events_Steps(ScenarioContext context) : base(context) { }

    [Given(@"an onboarded employer logs into the AAN portal")]
    public void GivenAnOnboardedEmployerLogsIntoTheAANPortal()
    {
        var user = context.GetUser<AanEmployerOnBoardedUser>();

        EmployerSign(user);

        networkHubPage = new Employer_NetworkHubPage(context);
    }

    [Then(@"the user should be able to successfully signup for a future event")]
    public void SignupForAFutureEvent() => SignupForAFutureEvent(networkHubPage);

    [Then(@"the user should be able to successfully Cancel the attendance for a signed up event")]
    public new void CancelTheAttendance() => base.CancelTheAttendance();

    [Then(@"the user should be able to successfully filter events by date")]
    public new void FilterByDate() => base.FilterByDate();

    [Then(@"the user should be able to successfully filter events by event format")]
    public new void FilterByEventFormat() => base.FilterByEventFormat();

    [Then(@"the user should be able to successfully filter events by event type")]
    public new void FilterByEventType() => base.FilterByEventType();

    [Then(@"the user should be able to successfully filter events by regions")]
    public new void FilterByEventRegion() => base.FilterByEventRegion();

    [Then(@"the user should be able to successfully filter events by multiple combination of filters")]
    public new void FilterByMultipleCombination() => base.FilterByMultipleCombination();
}
