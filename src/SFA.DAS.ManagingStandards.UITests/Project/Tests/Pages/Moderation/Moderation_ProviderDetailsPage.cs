
using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation
{
    public class Moderation_ProviderDetailsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"Provider details for {MS_DataHelper.ProviderName}";
        private By ChangeLink => By.XPath("//a[contains(text(),'Change')]");

        public Moderation_ProviderDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public Moderation_UpdateProviderPage ChangeProviderDetail()
        {
            formCompletionHelper.Click(ChangeLink);
            return new Moderation_UpdateProviderPage(context);
        }
    }
}
