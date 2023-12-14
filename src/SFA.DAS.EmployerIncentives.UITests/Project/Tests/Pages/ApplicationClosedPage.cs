using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationClosedPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => "Sorry, applications for incentive payments have closed";
    }
}
