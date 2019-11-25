using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EnterOpportunityDetailsPage : RAA_EnterFurtherDetailsPage
    {
        protected override string PageTitle => "Enter opportunity details";

        public RAA_EnterOpportunityDetailsPage(ScenarioContext context) : base(context) { }
    }
}
