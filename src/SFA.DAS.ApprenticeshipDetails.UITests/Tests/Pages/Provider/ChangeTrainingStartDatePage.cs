using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ChangeTrainingStartDatePage: ApprovalsBasePage
    {
        protected override string PageTitle => "Change training start date";
        protected override By ContinueButton => By.Id("buttonSubmitForm");
        private static By SendButton => By.Id("buttonSubmitChangeOfStartDate");
        private static By ApprenticeshipStartDateHintText => By.Id("apprenticeship-startdate-hint");
        private static By StartDate_Day => By.Id("startdate-day");
        private static By StartDate_Month => By.Id("startdate-month");
        private static By StartDate_Year => By.Id("startdate-year");
        private static By ReasonInputFields => By.CssSelector("textarea[Id='ReasonForChangeOfStartDate']");
        private static By ChangeActualTrainingStartDateErrorMessage => By.XPath("//a[contains(text(),'You must change the actual training start date')]");
        private static By EnterAReasonErrorMessage => By.XPath("//a[contains(text(),'You must enter a reason for requesting a change of start date')]");
        private static By CourseAvailableToApprenticesWithStartDateAfterDateErrorMessage => By.XPath("//a[contains(text(),'This training course is only available')]");

        public ChangeTrainingStartDatePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public ChangeTrainingStartDatePage ValidateStartDateHintText(DateTime currentStartDate)
        {
            string expectedValue = $"The current start date for the training is {currentStartDate.Day} {currentStartDate.Month} {currentStartDate.Year}";
            string displayedValue = pageInteractionHelper.GetText(ApprenticeshipStartDateHintText);

            Assert.AreEqual(expectedValue, displayedValue);
            return this;
        }
        public ConfirmPlannedTrainingEndDatePage EnterValidChangeOfStartDateDetails(DateTime newTrainingStartDate, string reason)
        {
            formCompletionHelper.EnterText(StartDate_Day, newTrainingStartDate.Day);
            formCompletionHelper.EnterText(StartDate_Month, newTrainingStartDate.Month);
            formCompletionHelper.EnterText(StartDate_Year, newTrainingStartDate.Year);
            formCompletionHelper.EnterText(ReasonInputFields, reason);
            formCompletionHelper.Click(ContinueButton);

            return new ConfirmPlannedTrainingEndDatePage(context);
        }

        public ChangeTrainingStartDatePage ClickContinueButtonWithValidationErrors()
        {
            formCompletionHelper.Click(ContinueButton);
            return this;
        }

        public void ConfirmDefaultValidationErrorMessagesDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeActualTrainingStartDateErrorMessage), 
                    "Change Actual Training Start Date error message not displayed");
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EnterAReasonErrorMessage), 
                    "You Must enter a reason error message not displayed");

            });
        }
        public ChangeTrainingStartDatePage ValidateStandardVersionStartDateErrorMessage(DateTime newTrainingStartDate)
        {
            formCompletionHelper.EnterText(StartDate_Day, newTrainingStartDate.Day);
            formCompletionHelper.EnterText(StartDate_Month, newTrainingStartDate.Month);
            formCompletionHelper.EnterText(StartDate_Year, newTrainingStartDate.Year);
            formCompletionHelper.Click(ContinueButton);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CourseAvailableToApprenticesWithStartDateAfterDateErrorMessage),
                "Training Course Available to Apprentices With Start Date After error message not displayed");

            return this;
        }

    }
}
