using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class ContractForServicesTemplatePage : ModeratorBasePage
    {
        protected override string PageTitle => "Contract for services template with employers";

        public ContractForServicesTemplatePage(ScenarioContext context) : base(context) { objectContext.SetIsUploadFile(); }
    }
}