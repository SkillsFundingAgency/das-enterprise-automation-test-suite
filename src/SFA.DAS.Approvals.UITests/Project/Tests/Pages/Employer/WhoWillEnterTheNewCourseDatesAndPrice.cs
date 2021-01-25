using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhoWillEnterTheNewCourseDatesAndPrice : ApprovalsBasePage
    {
        protected override string PageTitle => "Who will enter the new course dates and price?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By WhoWillEnterTheNewCourseDatesAndPriceContinueBtn => By.XPath("//button[@class='govuk-button']");


        public WhoWillEnterTheNewCourseDatesAndPrice(ScenarioContext context): base(context) => _context = context;

        public ConfirmRequestForChangeOfProviderPage NewTrainingProviderWillAddThemLater()
        {
            formCompletionHelper.SelectRadioOptionByText("SOUTHAMPTON ENGINEERING TRAINING ASSOCIATION LIMITED (THE) will add them later");
            formCompletionHelper.Click(WhoWillEnterTheNewCourseDatesAndPriceContinueBtn);
            return new ConfirmRequestForChangeOfProviderPage(_context);
        }

        public WhatIsTheNewStartDatePage SelectIWillAddThemNow()
        {
            formCompletionHelper.SelectRadioOptionByText("I'll add them now");
            formCompletionHelper.Click(WhoWillEnterTheNewCourseDatesAndPriceContinueBtn);
            return new WhatIsTheNewStartDatePage(_context);
        }
    }
}