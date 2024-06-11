using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ConfirmPlannedTrainingEndDatePage : ChangeTrainingStartDatePage
    {
        protected override string PageTitle => "Confirm the planned training end date";
        private static By UseSuggestedDateRadioOption => By.Id("useSuggestedDate-true");
        private static By EnterNewPlannedEndDateRadioOption => By.Id("useSuggestedDate-false");
        private static By PlannedEndDate_Day => By.Id("plannedEndDate-day");
        private static By PlannedEndDate_Month => By.Id("plannedEndDate-month");
        private static By PlannedEndDate_Year => By.Id("plannedEndDate-year");

        public ConfirmPlannedTrainingEndDatePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public CheckYourChangesBeforeSendingToEmployerPage SelectUseSuggestedPlannedEndDateAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(UseSuggestedDateRadioOption);
            formCompletionHelper.Click(ContinueButton);

            return new CheckYourChangesBeforeSendingToEmployerPage(context);
        }

    }
}
