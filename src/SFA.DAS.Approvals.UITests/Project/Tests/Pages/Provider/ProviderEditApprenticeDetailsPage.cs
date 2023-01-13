using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        private By EditDeliveryModelLink => By.Name("ChangeDeliveryModel");
        private By UpdateDetailsBtn => By.Id("continue-button");
        private By DeliveryModelLabel => By.XPath("//*[@id='editApprenticeship']/div[7]/p[2]");

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        public SelectDeliveryModelPage ClickEditDeliveryModel()
        {
            formCompletionHelper.ClickElement(EditDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ProviderConfirmChangesPage ClickUpdateDetails()
        {
            formCompletionHelper.ClickElement(UpdateDetailsBtn);
            return new ProviderConfirmChangesPage(context);
        }

        public ProviderEditApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(expected), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModelLabel);


    }
}
