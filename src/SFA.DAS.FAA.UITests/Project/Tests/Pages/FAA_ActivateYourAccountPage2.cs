using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage2 : BasePage
    {
        protected override string PageTitle => "Tell us more about you";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FAADataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By SaveAndContinue => By.Id("save-continue-button");
        private By SkipLink => By.Id("skip-link");

        public FAA_ActivateYourAccountPage2(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<FAADataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchPage ClickSaveAndContinue()
        {
            _formCompletionHelper.Click(SaveAndContinue);
            _pageInteractionHelper.WaitforURLToChange("apprenticeshipsearch");
            return new FAA_ApprenticeSearchPage(_context);
        }

        public FAA_ApprenticeSearchPage ClickSkipLink()
        {
            _formCompletionHelper.Click(SkipLink);
            return new FAA_ApprenticeSearchPage(_context);
        }
    }
}
