using OpenQA.Selenium;
using SFA.DAS.CovidRedundancy.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.CovidRedundancy.UITests.Project.Test.Pages
{
    public class NewApprenticeshipLandingPage : CovidRedundancyBasePage
    {
        protected override string PageTitle => "Find a new apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private By StartNowButtonForApprentice = By.CssSelector("a.das-panel-button");
        #endregion

        public NewApprenticeshipLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeDetailsPage SelectAprpenticesStartnow()
        {
            formCompletionHelper.Click(StartNowButtonForApprentice);
            return new ApprenticeDetailsPage(_context);
        }
    }
}
