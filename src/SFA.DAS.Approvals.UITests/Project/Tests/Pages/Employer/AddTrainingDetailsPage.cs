using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector(".das-show > h1");
        protected override string PageTitle => "Add training details";

        private By SaveAndContinueButton => By.CssSelector("button[id=continue-button]");

        private By DeliveryModelLabel => By.XPath("//p[text()='Delivery model']");

        private By DeliveryModelType => By.XPath("//p[text()='Delivery model'] // following-sibling :: p");

        private By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public AddTrainingDetailsPage(ScenarioContext context) : base(context)
        {
        }

        public ApproveApprenticeDetailsPage SubmitValidApprenticeTrainingDetails(bool isMF, int apprenticeNo = 0)
        {
            var courseStartDate = SetEIJourneyTestData(apprenticeNo);

            ClickStartMonth();

            if (isMF == false) EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ApproveApprenticeDetailsPage(context);
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new YouCantApproveThisApprenticeRequestUntilPage(context);
        }

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        public void ValidatePortableFlexiJobContent() => DeliveryModelAssertions("Portable flexi-job");

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel));
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink));
        }
    }
}