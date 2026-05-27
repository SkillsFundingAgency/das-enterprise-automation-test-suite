using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class WhenWillTheTrainingStartPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "When will the training start?";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private static By ReservationResumeFromDate => By.CssSelector(".govuk-inset-text p:nth-child(2)");

        private static By ErrorSummary => By.CssSelector(".govuk-error-summary__list li a[href^='#StartDate-']");

        public WhenWillTheTrainingStartPage ClickMonthRadioButton()
        {
            formCompletionHelper.ClickElement(RadioLabels);
            return new WhenWillTheTrainingStartPage(context);
        }

        public CheckDetailsAndReserveFundingPage ClickSaveAndContinueButton()
        {
            Continue();
            return new CheckDetailsAndReserveFundingPage(context);
        }

        public WhenWillTheTrainingStartPage ClickSaveAndContinueButtonAndExpectProblem()
        {
            Continue();
            return this;
        }

        public void VerifyReserveFromMonth(DateTime? reserveFromMonth)
        {
            if (reserveFromMonth != null)
                pageInteractionHelper.VerifyText(ReservationResumeFromDate, reserveFromMonth?.ToString("MMMM yyyy"));
        }

        public bool VerifySuggestedStartMonthOptions(DateTime? firstMonth, DateTime? secondMonth, DateTime? thirdMonth)
        {
            var expectedMonths = (new List<string> { firstMonth?.ToString("MMMM yyyy"), secondMonth?.ToString("MMMM yyyy"), thirdMonth?.ToString("MMMM yyyy") }).
                Where(p => !string.IsNullOrWhiteSpace(p));

            var actualMonths = pageInteractionHelper.
                GetAvailableRadioOptions().
                Select(p => p.Trim());

            if (actualMonths.SequenceEqual(expectedMonths))
                return true;

            throw new Exception("Suggested months verification failed: "
                + "\n Expected: '" + string.Join(",", expectedMonths)
                + "\n Found: '" + string.Join(",", actualMonths));
        }

        public void VerifyProblem(string problem) => pageInteractionHelper.VerifyText(ErrorSummary, problem);

    }
}