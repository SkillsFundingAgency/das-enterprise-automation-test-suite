using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation
{
    public class Moderation_UpdateProviderPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"Update the provider description for {MS_DataHelper.ProviderName}";
        private By UpdateDescriptionTextField => By.Id("ProviderDescription");
        private By UpdatedText => By.CssSelector("p.app-preline");

        public Moderation_UpdateProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        public Moderation_CheckProviderUpdatePage EnterUpdateDescriptionAndContinue()
        {
            formCompletionHelper.EnterText(UpdateDescriptionTextField, "test");
            Continue();
            return new Moderation_CheckProviderUpdatePage(context);
        }

        public string GetUpdateDescriptionText() =>
            pageInteractionHelper.GetText(UpdatedText);
    }
}
