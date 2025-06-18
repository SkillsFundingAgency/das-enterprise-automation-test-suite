using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;

public class YouCannotCreateAnotherFundingReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "You cannot create another funding reservation";
}