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

        private By VacancyStatus => By.CssSelector("#applicationTable .applicant span");


        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<RAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public string GetVacancyStatus()
        {
            return _pageInteractionHelper.GetText(VacancyStatus);
        }
    }
}
