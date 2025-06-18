using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class OrganisationsAndAgreementsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "View employers and manage permissions";
    }
}
