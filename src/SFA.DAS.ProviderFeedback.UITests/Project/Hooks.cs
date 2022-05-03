using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderFeedback.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly DbConfig _dbConfig;
        private ProviderFeedbackSqlHelper _providerFeedbackSqlHelper;
        private readonly ScenarioContext _context;
        private TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private string _uniqueSurveyCode;
        private readonly string[] _tags;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            _dbConfig = context.Get<DbConfig>();
            _tags = context.ScenarioInfo.Tags;
        }

        [BeforeScenario(Order = 21)]
        public void SetUpHelpers()
        {
            _providerFeedbackSqlHelper = new ProviderFeedbackSqlHelper(_dbConfig);

            _context.Set(_providerFeedbackSqlHelper);
        }

        [BeforeScenario(Order = 22)]
        public void NavigateToProviderFeedbackpage()
        {
            _tabHelper = _context.Get<TabHelper>();

            _uniqueSurveyCode = _providerFeedbackSqlHelper.GetUniqueSurveyCode();

            _objectContext.SetUniqueSurveyCode(_uniqueSurveyCode);

        }

        [BeforeScenario(Order = 23)]
        public void ClearDownDataForAdhocJourney()
        {
            if (_tags.Contains("providerfeedback03"))
                _providerFeedbackSqlHelper.ClearDownDataForAdhocJourney();
        }

        [AfterScenario(Order = 34)]
        public void ClearDownGetUniqueSurveyCodeData() => _tryCatch.AfterScenarioException(() => _providerFeedbackSqlHelper.ClearDownDataFromUniqueSurveyCode(_uniqueSurveyCode));
    }
}
