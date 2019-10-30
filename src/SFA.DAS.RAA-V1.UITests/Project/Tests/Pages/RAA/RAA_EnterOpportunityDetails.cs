using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EnterOpportunityDetails : RAA_EnterFurtherDetailsPage
    {
        protected override string PageTitle => "Enter opportunity details";

        public RAA_EnterOpportunityDetails(ScenarioContext context) : base(context) { }
    }
}
