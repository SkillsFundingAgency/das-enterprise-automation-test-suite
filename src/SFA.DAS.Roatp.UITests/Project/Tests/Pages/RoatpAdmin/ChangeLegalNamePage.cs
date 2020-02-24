using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeLegalNamePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change legal name for {objectContext.GetProviderName()}";

        public ChangeLegalNamePage(ScenarioContext context) : base(context) { }
    }
}
