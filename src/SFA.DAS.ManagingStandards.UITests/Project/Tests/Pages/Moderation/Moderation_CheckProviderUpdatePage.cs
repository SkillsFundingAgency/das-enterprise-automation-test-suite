using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation
{
    public class Moderation_CheckProviderUpdatePage : ManagingStandardsBasePage
    {
        protected override string PageTitle => $"Check the provider description entry for {MS_DataHelper.ProviderName}";

        public Moderation_CheckProviderUpdatePage(ScenarioContext context) : base(context) => VerifyPage();

        public Moderation_ProviderDetailsPage ContinueOnCheckProviderUpdatePage()
        {
            Continue();
            return new Moderation_ProviderDetailsPage(context);
        }
    }
}
