using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector(".das-show > h1");
        protected override string PageTitle => "Add training details";
        protected override By ContinueButton => By.XPath("//button[text()='Add']");
        private By DeliveryModelLabel => By.XPath("//p[text()='Apprenticeship delivery model']");
        private By DeliveryModelType => By.XPath("//p[text()='Apprenticeship delivery model'] // following-sibling :: p");
        private By EditDeliverModelLink => By.Name("ChangeDeliveryModel");
        private By ErrorMessagelLink => By.XPath("//*[@id='validationSummaryErrorList']/li/a");
        private By StartDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-StartDate']");
        private By EndDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-EndDate']");

        public ProviderAddTrainingDetailsPage(ScenarioContext context) : base(context)
        {
        }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeTrainingDetails()
        {
            ClickStartMonth();

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);

            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {
            ClickStartMonth();

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(ContinueButton);

            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }

        internal void VerifyOverlappingTrainingDetailsError(bool displayStartDateError, bool displayEndDateError)
        {
            ClickStartMonth();

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(ContinueButton);

            ValidateOltdErrorMessage(StartDateErrorMessagelLink, displayStartDateError);
            ValidateOltdErrorMessage(EndDateErrorMessagelLink, displayEndDateError);
        }

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }

        private bool CheckRPLCondition(bool rpl = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear));
            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & year == 2022) rpl = true;
            if (year > 2022) rpl = true;
            return rpl;
        }

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel), "Delivery Model Label not displayed");
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink), "Edit Delivery Model link not displayed");
        }

        private void ValidateOltdErrorMessage(By locator, bool shouldBeDisplayed)
        {
            if (shouldBeDisplayed)
            {
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message not dsiplayed");
                string expectedMessage = "The date overlaps with existing dates for the same apprentice";
                string actualMessage = pageInteractionHelper.GetText(locator);
                StringAssert.StartsWith(expectedMessage, actualMessage, "Incorrect Date Overlaps Message displayed");
            }
            else
            {
                Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message should not be dsiplayed");
            }
        }
    }
}