using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : BasePage
    {
        protected override string PageTitle => _dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly RAADataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By InfoSummary => By.CssSelector(".info-summary > p");


        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<RAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public string GetInfoSummary()
        {
            return _pageInteractionHelper.GetText(InfoSummary);
        }
    }
}
