using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class HasTheApprenticeBeenMadeRedundantPage : ApprovalsBasePage
    {
        protected override string PageTitle => $"Has {apprenticeDataHelper.ApprenticeFullName} been made redundant?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
       protected override By ContinueButton => By.CssSelector("#submit-redundancy-confirm");

        public HasTheApprenticeBeenMadeRedundantPage(ScenarioContext context) : base(context) => _context = context;

        public StopApprenticeshipPage ClickARadioButtonAndContinue()
        {
            var RadioButtonList = new List<string> { "Yes", "No" };
            formCompletionHelper.SelectRadioOptionByText(RadioButtonList[new Random().Next(RadioButtonList.Count)]);
            Continue();
            return new StopApprenticeshipPage(_context);
        }




    }
}
