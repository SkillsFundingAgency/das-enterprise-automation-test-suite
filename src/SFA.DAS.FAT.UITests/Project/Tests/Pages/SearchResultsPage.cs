using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    class SearchResultsPage : BasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FATConfig _config;
        #endregion

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetFATConfig<FATConfig>();
            VerifyPage();
        }      
    }
}
