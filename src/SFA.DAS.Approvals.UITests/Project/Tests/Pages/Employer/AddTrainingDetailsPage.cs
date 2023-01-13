using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
        protected override string PageTitle => "Add training details";

        private static By SaveAndContinueButton => By.CssSelector("button[id=continue-button]");

        private static By DeliveryModelLabel => By.XPath("//p[text()='Delivery model']");

        private static By DeliveryModelType => By.XPath("//p[text()='Delivery model'] // following-sibling :: p");

        private static By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public AddTrainingDetailsPage(ScenarioContext context) : base(context) { }

        public ApproveApprenticeDetailsPage SubmitValidTrainingDetails(bool isMF)
        {
            var courseStartDate = GetCourseStartDate();

            ClickStartMonth();

            if (isMF == false) EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            SaveAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ApproveApprenticeDetailsPage(context);
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
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