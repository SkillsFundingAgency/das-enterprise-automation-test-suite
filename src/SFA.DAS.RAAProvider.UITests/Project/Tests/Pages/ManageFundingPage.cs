using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ManageFundingPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Funding for non-levy employers";
    }
}
