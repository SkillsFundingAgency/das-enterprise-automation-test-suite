using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeProviderTypePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change provider type for {objectContext.GetProviderName()}";

        public ChangeProviderTypePage(ScenarioContext context) : base(context) { }
    }
}
