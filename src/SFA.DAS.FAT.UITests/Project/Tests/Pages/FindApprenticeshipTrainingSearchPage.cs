using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    class FindApprenticeshipTrainingSearchPage : BasePage
    {
        protected override string PageTitle => "Find apprenticeship training";
        private const string ApprenticeshipName = "Software tester";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FATConfig _config;
        #endregion

        #region Locators
        private By SearchForaTrainingProviderLink => By.LinkText("search for a training provider");
        private By SearchApprenticeshipTrainingButton => By.Id("submit-keywords");
        private By ApprenticeshipNameTextField => By.Id("keywords");
        #endregion

        public FindApprenticeshipTrainingSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetFATConfig<FATConfig>();
            VerifyPage();
        }

        public SearchResultsPage SearchApprenticeshipName()
        {
            _formCompletionHelper.EnterText(ApprenticeshipNameTextField, ApprenticeshipName);
            _formCompletionHelper.Click(SearchApprenticeshipTrainingButton);
            return new SearchResultsPage(_context);
        }
    }
}
