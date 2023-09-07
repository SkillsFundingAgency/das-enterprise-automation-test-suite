using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class HasTheApprenticeBeenMadeRedundantPage : ApprovalsBasePage
    {
        protected override string PageTitle => $"Has {apprenticeDataHelper.ApprenticeFullName} been made redundant?";

        protected override string AccessibilityPageTitle => "Has apprentice been made redundant";

        protected override bool TakeFullScreenShot => false;

        #region Helpers and Context
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        protected override By ContinueButton => By.Id("submit");

        public HasTheApprenticeBeenMadeRedundantPage(ScenarioContext context) : base(context) => _dataHelper = context.Get<ApprenticeDataHelper>();

        public StopApprenticeshipPage ClickARadioButtonAndContinue()
        {
            List<string> RadioButtonList = new List<string> { "Yes", "No" };
            _dataHelper.MadeRedundant = RadioButtonList[new Random().Next(RadioButtonList.Count)];
            formCompletionHelper.SelectRadioOptionByText(_dataHelper.MadeRedundant);
            Continue();
            return new StopApprenticeshipPage(context);
        }
    }
}
