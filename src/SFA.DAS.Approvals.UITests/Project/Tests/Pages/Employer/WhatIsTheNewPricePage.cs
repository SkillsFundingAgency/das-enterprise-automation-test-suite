using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewPricePage : ApprovalsBasePage
    {
        protected override string PageTitle => $"What is the agreed price of completing the training with {changeOfPartyConfig.NewProviderName}?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewPriceInput => By.Id("input-newprice");
        private By ContinueBtn => By.Id("continue-button");

        public WhatIsTheNewPricePage(ScenarioContext context) : base(context) => _context = context; 

        public WhatIsTheNewPricePage EnterInvalidPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, -1000);
            formCompletionHelper.Click(ContinueBtn);

            return this;
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterNewPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, 1000);
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(_context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, 2000);
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(_context);
        }
    }
}
