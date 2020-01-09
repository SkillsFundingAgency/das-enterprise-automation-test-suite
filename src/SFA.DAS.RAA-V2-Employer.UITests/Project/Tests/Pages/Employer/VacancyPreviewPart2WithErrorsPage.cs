using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class VacancyPreviewPart2WithErrorsPage : VacancyPreviewPart2Page
    {
        protected override string PageTitle => "Please fix these errors";

        protected override By PageHeader => By.CssSelector(".govuk-error-summary");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public VacancyPreviewPart2WithErrorsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public string GetErrorMessages()
        {
            return _pageInteractionHelper.GetText(PageHeader);
        }

    }
}
