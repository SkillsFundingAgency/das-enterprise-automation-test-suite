using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApprenticeshipSummaryPage : BasePage
    {

        protected override string PageTitle => "Apprenticeship summary";

        protected override By PageHeader => By.CssSelector("#vacancy-info .heading-large");

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By VacancyTitle => By.CssSelector("#vacancy-title");

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void VerifyVacancyTitle() => _pageInteractionHelper.GetText(VacancyTitle).ContainsCompareCaseInsensitive(_objectContext.GetVacancyTitle());
    }
}
