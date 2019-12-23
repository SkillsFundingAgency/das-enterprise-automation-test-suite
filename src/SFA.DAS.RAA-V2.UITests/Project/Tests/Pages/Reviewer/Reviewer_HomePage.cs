using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_HomePage : BasePage
    {
        protected override By PageHeader => ReviewVacancyButton;

        protected override string PageTitle => "Review Vacancy";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By ReviewVacancyButton => By.CssSelector(".govuk-button[type='submit']");

        private By SearchTerm => By.Id("SearchTerm");

        private By SearchVacancy => By.CssSelector(".search-submit button");

        public Reviewer_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public Reviewer_VacancyPreviewPage ReviewVacancy()
        {
            _formCompletionHelper.EnterText(SearchTerm, _objectContext.GetVacancyReference());
            _formCompletionHelper.Click(SearchVacancy);
            _formCompletionHelper.ClickLinkByText("Review");
            return new Reviewer_VacancyPreviewPage(_context);
        }
    }
}
