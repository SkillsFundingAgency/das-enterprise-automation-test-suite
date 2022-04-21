using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class DeleteOrgPage : OrgPage
    {
        protected override string PageTitle => dataHelper.NewOrgNameWithOutSuffix;

        public DeleteOrgPage(ScenarioContext context) : base(context, false) { }
    }
}
