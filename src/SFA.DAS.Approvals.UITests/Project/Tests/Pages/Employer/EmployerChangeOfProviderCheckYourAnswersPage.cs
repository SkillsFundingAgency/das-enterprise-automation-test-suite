using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EmployerChangeOfProviderCheckYourAnswersPage : ApprovalsBasePage
    {
        protected override string PageTitle => $"Confirm details and send request to {changeOfPartyConfig.NewProviderName}";

        private static By ChangeStartDateLink => By.Id("change-start-date-link");
        private static By ChangeEndDateLink => By.Id("change-end-date-link");
        private static By ChangePriceLink => By.Id("change-price-link");
        private static By ConfirmBtn => By.Id("confirm-and-send-button");

        public EmployerChangeOfProviderCheckYourAnswersPage(ScenarioContext context) : base(context) { }

        public WhatIsTheNewStartDatePage ClickChangeStartDate()
        {
            formCompletionHelper.Click(ChangeStartDateLink);

            return new WhatIsTheNewStartDatePage(context);
        }

        public WhatIsTheNewEndDatePage ClickChangeEndDate()
        {
            formCompletionHelper.Click(ChangeEndDateLink);

            return new WhatIsTheNewEndDatePage(context);
        }

        public WhatIsTheNewPricePage ClickChangePrice()
        {
            formCompletionHelper.Click(ChangePriceLink);

            return new WhatIsTheNewPricePage(context);
        }

        public ChangeOfTrainingProviderRequestedPage ClickConfirmAndSend()
        {
            formCompletionHelper.Click(ConfirmBtn);
            return new ChangeOfTrainingProviderRequestedPage(context);
        }
    }
}
