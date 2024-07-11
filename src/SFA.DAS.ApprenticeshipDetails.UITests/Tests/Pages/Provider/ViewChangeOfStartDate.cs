using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ViewChangeOfStartDate(ScenarioContext context) : ChangeOfPriceViewChangeRequestPage(context)
    {
        protected override string PageTitle => "View change of start date";
        private static By TrainingStartDateRequestedValue => By.Id("training-start-date-NewValue");
        private static By TrainingStartDateCurrentValue => By.Id("training-start-date-OriginalValue");
        private static By PlannedEndDateRequestedValue => By.Id("PlannedEndDate-NewValue");
        public static By ReasonValue => By.Id("reason-for-change-NewValue");

        public new ViewChangeOfStartDate VerifyPendingEmployerReviewTagIsDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PendingEmployerReviewTag), "Pending Employer Review tag not displayed");
            return this;
        }

        public ViewChangeOfStartDate ValidateRequestedValues(DateTime requestedStartDate, DateTime requestedEndDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(requestedStartDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(TrainingStartDateRequestedValue), "Request Training Start Date mismatch");
                Assert.AreEqual(requestedEndDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(PlannedEndDateRequestedValue), "Request Training End Date mismatch");
                Assert.AreEqual(reason, pageInteractionHelper.GetText(ReasonValue), "Requested reason mismatch");
            });
            return this;
        }
    }
}
