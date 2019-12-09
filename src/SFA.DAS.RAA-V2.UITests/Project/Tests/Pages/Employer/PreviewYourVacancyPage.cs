using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class PreviewYourVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Preview your vacancy";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion

        public PreviewYourVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }

        public VacancyPreviewPart2Page PreviewVacancy()
        {
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
