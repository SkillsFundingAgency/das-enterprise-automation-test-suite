using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AppBenefitsPage : ApprenticeBasePage
    {
        protected override string PageTitle => "WHAT ARE THE BENEFITS FOR ME?";

        public AppBenefitsPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(Heading1, "WHAT ARE MY FUTURE PROSPECTS ONCE I’VE SUCCESSFULLY FINISHED MY APPRENTICESHIP?");
            pageInteractionHelper.VerifyText(Heading2, "HOW MUCH CAN YOU EARN?");
            pageInteractionHelper.VerifyText(Heading3, "WHAT WILL MY APPRENTICESHIP COST ME?");
        }
    }
}
