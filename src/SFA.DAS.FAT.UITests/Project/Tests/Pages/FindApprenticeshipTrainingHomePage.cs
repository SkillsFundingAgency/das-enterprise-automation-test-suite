using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    class FindApprenticeshipTrainingHomePage : BasePage
    {
        protected override string PageTitle => "Find apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FATConfig _config;
        #endregion

        #region Locators
        private By StartButton => By.Id("start-button");
        #endregion

        public FindApprenticeshipTrainingHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetFATConfig<FATConfig>();
            VerifyPage();
        }

        public FindApprenticeshipTrainingSearchPage ClickStartButtonToSearchApprenticeshipName()
        {
            _formCompletionHelper.Click(StartButton);
            return new FindApprenticeshipTrainingSearchPage(_context);
        }

       
    }
}
