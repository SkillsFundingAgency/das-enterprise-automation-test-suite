using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation
{
    public class Moderation_HomePage : ManagingStandardsBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        public Moderation_HomePage(ScenarioContext context) : base(context) { }

        public Moderation_SearchPage SearchForTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Search for an apprenticeship training provider");
            return new Moderation_SearchPage(context);
        }
    }
}
