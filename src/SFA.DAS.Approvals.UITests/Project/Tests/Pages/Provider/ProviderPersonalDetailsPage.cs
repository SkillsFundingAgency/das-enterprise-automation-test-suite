using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Personal details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'continue')]");
        private static By Uln => By.Id("Uln");
        private static By AddButton => By.XPath("//button[text()='Add']");
        private By DeliveryModelLabel => By.XPath("//p[text()='Apprenticeship delivery model']");
        private By DeliveryModelType => By.XPath("//p[text()='Apprenticeship delivery model'] // following-sibling :: p");
        private By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public ProviderPersonalDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProviderTrainingDetailsPage SubmitValidApprenticePersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            formCompletionHelper.Click(ContinueButton);

            return new ProviderTrainingDetailsPage(context);
        }

        private new void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        private void DeliveryModelAssertions(string delModelType)
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel));
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink));
        }
    }
}