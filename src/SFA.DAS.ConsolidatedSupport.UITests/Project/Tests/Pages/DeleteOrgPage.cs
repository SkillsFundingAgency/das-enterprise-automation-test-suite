using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class DeleteOrgPage(ScenarioContext context) : OrgPage(context, false)
    {
        protected override string PageTitle => dataHelper.NewOrgNameWithOutSuffix;
    }
}
