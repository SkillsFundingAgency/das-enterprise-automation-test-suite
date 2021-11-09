using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : RAA_VacancyLinkBasePage
    {
        protected override string PageTitle => vacancyTitledataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By VacancyStatus => By.CssSelector("#applicationTable .applicant span");

        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public string GetVacancyStatus() => _pageInteractionHelper.GetText(VacancyStatus);

        public new void SetVacancyReference() => _objectContext.SetVacancyReference(RegexHelper.GetVacancyReferenceFromUrl(GetUrl()));

        public RAA_ApplicationPreviewPage ViewApplication()
        {
            formCompletionHelper.ClickLinkByText("View application");
            return new RAA_ApplicationPreviewPage(_context);
        }

        public RAA_VacancyApplicationPage AnonymousView()
        {
            formCompletionHelper.ClickLinkByText("Anonymous view");
            return new RAA_VacancyApplicationPage(_context);
        }
    }
}
