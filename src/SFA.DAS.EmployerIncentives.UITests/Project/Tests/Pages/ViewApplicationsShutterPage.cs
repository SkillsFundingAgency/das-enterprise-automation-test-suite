using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{objectContext.GetOrganisationName()} does not have any hire a new apprentice payment applications";

        public ViewApplicationsShutterPage(ScenarioContext context) : base(context) { }
    }
}
