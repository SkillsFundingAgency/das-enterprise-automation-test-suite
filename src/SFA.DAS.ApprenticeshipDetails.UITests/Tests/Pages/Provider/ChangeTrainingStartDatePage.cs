using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
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
        private static By StartDate_Month => By.Id("startdate_Month");
        private static By StartDate_Year => By.Id("startdate-year");
        private static By ReasonInputFields => By.Id("ReasonForChangeOfStartDate");
        private static By ChangeActualTrainingStartDateErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipActualStartDate']");
        private static string ChangeActualTrainingStartDateErrorText => "You must change the actual training start date";


        public ChangeTrainingStartDatePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public ChangeTrainingStartDatePage ValidateStartDateHintText(DateTime currentStartDate)
        {
            string expectedValue = $"The current start date for the training is {currentStartDate.Day} {currentStartDate.Month} {currentStartDate.Year}";
            string displayedValue = pageInteractionHelper.GetText(ApprenticeshipStartDateHintText);

            Assert.AreEqual(expectedValue, displayedValue);
            return this;
        }
        public ProviderApprenticeDetailsPage EnterValidChangeOfPriceDetails(DateTime newTrainingStartDate, string reason)
        {
            formCompletionHelper.EnterText(StartDate_Day, newTrainingStartDate.Day);
            formCompletionHelper.EnterText(StartDate_Month, newTrainingStartDate.Month);
            formCompletionHelper.EnterText(StartDate_Year, newTrainingStartDate.Year);
            formCompletionHelper.EnterText(ReasonInputFields, reason);
            formCompletionHelper.Click(ContinueButton);

            // on the next page, click "Now send to the employer for approvals"
            formCompletionHelper.Click(SendButton);

            return new ProviderApprenticeDetailsPage(context);
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
                Assert.AreEqual(pageInteractionHelper.GetText(ChangeActualTrainingStartDateErrorMessage), ChangeActualTrainingStartDateErrorText);
                // more validations to be added here
            });
        }

    }
}
