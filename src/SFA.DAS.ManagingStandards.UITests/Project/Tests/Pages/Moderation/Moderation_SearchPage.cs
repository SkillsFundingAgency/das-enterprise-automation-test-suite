using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation
{
    public class Moderation_SearchPage : ManagingStandardsBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship training provider";
        private static By UkprnSearch => By.Id("Ukprn");

        public Moderation_SearchPage(ScenarioContext context) : base(context) => VerifyPage();

        public Moderation_ProviderDetailsPage SearchTrainingProviderByUkprn(string text)
        {
            formCompletionHelper.EnterText(UkprnSearch, text);
            Continue();
            return new Moderation_ProviderDetailsPage(context);
        }
    }
}
