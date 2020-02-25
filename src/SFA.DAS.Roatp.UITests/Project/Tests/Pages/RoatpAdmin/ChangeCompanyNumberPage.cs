using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeCompanyNumberPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change company number for {objectContext.GetProviderName()}";

        public ChangeCompanyNumberPage(ScenarioContext context) : base(context) { }

    }
}
