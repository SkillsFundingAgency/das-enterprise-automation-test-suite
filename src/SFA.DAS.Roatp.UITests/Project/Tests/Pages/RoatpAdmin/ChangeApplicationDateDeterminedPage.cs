using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeApplicationDateDeterminedPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change application determined date for {objectContext.GetProviderName()}";

        public ChangeApplicationDateDeterminedPage(ScenarioContext context) : base(context) { }

    }
}
