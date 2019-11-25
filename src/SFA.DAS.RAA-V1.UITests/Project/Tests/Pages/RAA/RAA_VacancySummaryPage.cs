using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : RAA_VacancyLinkBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private RegexHelper _regexHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By VacancyStatus => By.CssSelector("#applicationTable .applicant span");

        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public string GetVacancyStatus()
        {
            return _pageInteractionHelper.GetText(VacancyStatus);
        }

        public new void SetVacancyReference()
        {
            var vacref = _regexHelper.GetVacancyReferenceFromUrl(_pageInteractionHelper.GetUrl());
            _objectContext.SetVacancyReference(vacref);
        }

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
