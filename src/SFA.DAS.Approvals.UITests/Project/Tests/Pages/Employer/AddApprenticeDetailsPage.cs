using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage(ScenarioContext context) : AddAndEditApprenticeDetailsBasePage(context)
    {
        private static By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By DeliveryModelLabel => By.Id("delivery-model-label");

        private static By DeliveryModelType => By.Id("delivery-model-value");

        private static By EditDeliverModelLink => By.Id("change-delivery-model-link");

        protected override string PageTitle => "Add apprentice details";

        public ApproveApprenticeDetailsPage SubmitValidApprenticeDetails(bool isMF)
        {
            SubmitValidPersonalDetails();
            SubmitValidTrainingDetails(isMF);

            return new ApproveApprenticeDetailsPage(context);
        }

        public void SubmitValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();
            EnterDob();
        }

        public void SubmitValidTrainingDetails(bool isMF)
        {
            var courseStartDate = GetCourseStartDate();

            ClickStartMonth();

            if (isMF == false) EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            SaveAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageAddValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            SaveAndContinue();

            return new YouCantApproveThisApprenticeRequestUntilPage(context);
        }

        public void ValidateRegularContent() => DeliveryModelAssertions("Regular");

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        public void ValidatePortableFlexiJobContent() => DeliveryModelAssertions("Portable flexi-job");

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel));
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink));
        }

        private void SaveAndContinue() => formCompletionHelper.ClickElement(SaveAndContinueButton);
    }
}