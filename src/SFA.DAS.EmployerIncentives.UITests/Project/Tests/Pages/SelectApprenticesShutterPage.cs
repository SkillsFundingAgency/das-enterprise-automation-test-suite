using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class SelectApprenticesShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} cannot apply for this payment";

        public SelectApprenticesShutterPage(ScenarioContext context) : base(context) { }
    }
}
