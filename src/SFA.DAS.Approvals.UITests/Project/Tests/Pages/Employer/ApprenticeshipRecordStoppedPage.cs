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

        public ApprenticeshipRecordStoppedPage(ScenarioContext context) : base(context)  { }

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(_context);
        }

    }
}
