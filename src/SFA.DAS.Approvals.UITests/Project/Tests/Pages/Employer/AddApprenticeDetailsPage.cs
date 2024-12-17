using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage(ScenarioContext context) : AddAndEditApprenticeDetailsBasePage(context)
    {
        private static By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By DeliveryModelLabel => By.Id("delivery-model-label");
        protected static By ErrorSummaryText => By.CssSelector(".govuk-error-summary__list a");
        protected static By ErrorSummaryTitle => By.Id("error-summary-title");

        private static By DeliveryModelType => By.Id("delivery-model-value");

        private static By EditDeliverModelLink => By.Id("change-delivery-model-link");

        protected override string PageTitle => "Add apprentice details";

        public ApproveApprenticeDetailsPage SubmitValidApprenticeDetails(bool checkStartDateNotEmpty)
        {
            SubmitValidPersonalDetails();
            SubmitValidTrainingDetails(checkStartDateNotEmpty);

            return new ApproveApprenticeDetailsPage(context);
        }

        public void SubmitValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();
            EnterDob();
        }

        public void SubmitValidTrainingDetails(bool checkStartDateNotEmpty)
        {
          var courseStartDate = GetCourseStartDate();

            ClickStartMonth();

            if (checkStartDateNotEmpty)
                VerifyStartDateIsPrePopulated();
            else
                EnterStartDate(courseStartDate);

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

        internal AddApprenticeDetailsPage SubmitInvalidDetailsAndCheckValidation(MappedApprenticeDetails apprenticeDetails)
        {
            EnterApprenticeName(apprenticeDetails.FirstName, apprenticeDetails.LastName);
            EnterApprenticeEmail(apprenticeDetails.EmailAddress);
            EnterDob(apprenticeDetails.DateOfBirth.Day, apprenticeDetails.DateOfBirth.Month, apprenticeDetails.DateOfBirth.Year);
            EnterStartDate(apprenticeDetails.StartDate);
            EnterEndDate(apprenticeDetails.EndDate);
            EnterTrainingCost(apprenticeDetails.TotalPrice);

            SaveAndContinue();

            return new AddApprenticeDetailsPage(context);
        }

        internal AddApprenticeDetailsPage ValidateExpectedError(MappedApprenticeDetails apprenticeDetails)
        {
            VerifyPage(ErrorSummaryTitle, "There is a problem");
            VerifyPage(ErrorSummaryText, apprenticeDetails.ErrorMessage);

            return new AddApprenticeDetailsPage(context);
        }

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel));
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink));
        }

        private void SaveAndContinue() => formCompletionHelper.ClickElement(SaveAndContinueButton);

        private void VerifyStartDateIsPrePopulated()
        {
            var startMonth = pageInteractionHelper.FindElement(StartDateMonth).GetValueAttribute();
            var startYear = pageInteractionHelper.FindElement(StartDateYear).GetValueAttribute();

            Assert.IsNotEmpty(startMonth, "Failed to validate startMonth field is pre-populated");
            Assert.IsNotEmpty(startYear, "Failed to validate startYear field is pre-populated");
        }
    }
}