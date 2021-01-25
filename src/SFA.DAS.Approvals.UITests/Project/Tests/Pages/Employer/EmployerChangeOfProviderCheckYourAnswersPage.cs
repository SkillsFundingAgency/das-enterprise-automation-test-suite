using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EmployerChangeOfProviderCheckYourAnswersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm details and send request to SOUTHAMPTON ENGINEERING TRAINING ASSOCIATION LIMITED (THE)";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeStartDateLink => By.Id("change-start-date-link");
        private By ChangeEndDateLink => By.Id("change-end-date-link");
        private By ChangePriceLink => By.Id("change-price-link");
        private By ConfirmBtn => By.Id("confirm-and-send-button");

        public EmployerChangeOfProviderCheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context; 
        
        public WhatIsTheNewStartDatePage ClickChangeStartDate()
        {
            formCompletionHelper.Click(ChangeStartDateLink);

            return new WhatIsTheNewStartDatePage(_context);
        }

        public WhatIsTheNewEndDatePage ClickChangeEndDate()
        {
            formCompletionHelper.Click(ChangeEndDateLink);

            return new WhatIsTheNewEndDatePage(_context);
        }

        public WhatIsTheNewPricePage ClickChangePrice()
        {
            formCompletionHelper.Click(ChangePriceLink);

            return new WhatIsTheNewPricePage(_context);
        }
        
        public ChangeOfTrainingProviderRequestedPage ClickConfirmAndSend()
        {
            formCompletionHelper.Click(ConfirmBtn);
            return new ChangeOfTrainingProviderRequestedPage(_context);
        }
    }
}
