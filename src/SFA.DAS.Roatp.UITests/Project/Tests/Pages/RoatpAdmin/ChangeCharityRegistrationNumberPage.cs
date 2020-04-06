using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeCharityRegistrationNumberPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change charity registration number for {objectContext.GetProviderName()}";

        public ChangeCharityRegistrationNumberPage(ScenarioContext context) : base(context) { }

    }
}
