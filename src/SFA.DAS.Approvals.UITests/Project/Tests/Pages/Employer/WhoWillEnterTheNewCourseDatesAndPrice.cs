using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhoWillEnterTheNewCourseDatesAndPrice : ApprovalsBasePage
    {
        protected override string PageTitle => "Who will enter the new course dates and price?";

        private By WhoWillEnterTheNewCourseDatesAndPriceContinueBtn => By.XPath("//button[@class='govuk-button']");

        public WhoWillEnterTheNewCourseDatesAndPrice(ScenarioContext context): base(context) { }

        public ConfirmRequestForChangeOfProviderPage NewTrainingProviderWillAddThemLater()
        {
            formCompletionHelper.SelectRadioOptionByText($"{changeOfPartyConfig.NewProviderName} will add them later");
            formCompletionHelper.Click(WhoWillEnterTheNewCourseDatesAndPriceContinueBtn);
            return new ConfirmRequestForChangeOfProviderPage(context);
        }

        public WhatIsTheNewStartDatePage SelectIWillAddThemNow()
        {
            formCompletionHelper.SelectRadioOptionByText("I'll add them now");
            formCompletionHelper.Click(WhoWillEnterTheNewCourseDatesAndPriceContinueBtn);
            return new WhatIsTheNewStartDatePage(context);
        }
    }
}