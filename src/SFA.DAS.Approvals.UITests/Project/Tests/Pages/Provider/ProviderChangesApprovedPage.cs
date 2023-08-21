using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChangesApprovedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Changes approved";

        private static By DeliveryModel => By.Id("apprentice-deliverymodel");

        public ProviderChangesApprovedPage(ScenarioContext context) : base(context) { }

        public bool IsDeliveryModelDisplayed() => pageInteractionHelper.IsElementDisplayed(DeliveryModel);

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModel);
    }
}
