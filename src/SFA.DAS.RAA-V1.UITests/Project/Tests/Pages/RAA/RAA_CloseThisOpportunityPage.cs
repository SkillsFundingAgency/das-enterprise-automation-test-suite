using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_CloseThisOpportunityPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Close this opportunity";

        public RAA_CloseThisOpportunityPage(ScenarioContext context) : base(context) { }

        public void CloseOpportunity()
        {
            formCompletionHelper.ClickButtonByText("Close opportunity");
        }
    }
}
