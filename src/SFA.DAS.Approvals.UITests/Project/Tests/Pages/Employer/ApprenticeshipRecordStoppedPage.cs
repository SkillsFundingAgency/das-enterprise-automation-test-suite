using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeshipRecordStoppedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprenticeship record stopped";
        protected override By ContinueButton => By.Id("continue-button");
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeshipRecordStoppedPage(ScenarioContext context) : base(context) => _context = context;

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(_context);
        }

    }
}
