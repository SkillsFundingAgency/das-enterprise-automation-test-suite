using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChangesApprovedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Changes approved";

        private static By DeliveryModel => By.Id("apprentice-deliverymodel");

        public bool IsDeliveryModelDisplayed() => pageInteractionHelper.IsElementDisplayed(DeliveryModel);

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModel);
    }
}
