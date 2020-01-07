using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : RAAV2CSSBasePage
    {

        protected override string PageTitle => "Which of your employers do you want to create a vacancy for?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV2ProviderDataHelper _dataHelper;
        #endregion

        public SelectEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV2ProviderDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyTitlePage SelectEmployer()
        {
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new VacancyTitlePage(_context);
        }
    }
}
