using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
        protected override string PageTitle => "Edit training details";
        private static By EditDeliveryModelLink => By.CssSelector("#change-delivery-model-link");
        private static By DeliveryModelLabel => By.XPath("//*[@id='draftApprenticeshipSection2']/div[2]/p[2]");

        protected override By AddButtonSelector => By.XPath("//button[text()='Save']");

        public EditTrainingDetailsPage(ScenarioContext context) : base(context)
        {
        }

        public bool IsEditDeliveryModelLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditDeliveryModelLink);
        public bool ConfirmDeliveryModelLabelText(string deliveryModel)
        {
            if (pageInteractionHelper.VerifyText(DeliveryModelLabel, deliveryModel) == true)
            {
                return true;
            }
            else return false;
        }

        public SelectDeliveryModelPage ClickEditDeliveryModelLink()
        {
            formCompletionHelper.ClickElement(EditDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ApproveApprenticeDetailsPage SaveEditedTrainingDetails()
        {
            formCompletionHelper.ClickElement(AddButtonSelector);
            return new ApproveApprenticeDetailsPage(context);
        }

    }
}