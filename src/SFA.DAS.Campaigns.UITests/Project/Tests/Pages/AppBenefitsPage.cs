using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class AppBenefitsPage : CampaingnsBasePage
    {
        protected override string PageTitle => "WHAT ARE THE BENEFITS FOR ME?";

        private By Heading1 => By.CssSelector("#h1");
        private By Heading2 => By.CssSelector("#h2");
        private By Heading3 => By.CssSelector("#h3");

        public AppBenefitsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            VerifyHeading();
        }

        private void VerifyHeading()
        {
            pageInteractionHelper.VerifyText(Heading1, "WHAT ARE MY FUTURE PROSPECTS ONCE I’VE SUCCESSFULLY FINISHED MY APPRENTICESHIP?");
            pageInteractionHelper.VerifyText(Heading2, "HOW MUCH CAN YOU EARN?");
            pageInteractionHelper.VerifyText(Heading3, "WHAT WILL MY APPRENTICESHIP COST ME?");
        }
    }
}
