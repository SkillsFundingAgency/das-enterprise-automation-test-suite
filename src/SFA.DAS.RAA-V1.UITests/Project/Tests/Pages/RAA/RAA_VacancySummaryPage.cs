using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : BasePage
    {
        protected override string PageTitle => _dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly RAADataHelper _dataHelper;
        #endregion

        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }
    }
}
