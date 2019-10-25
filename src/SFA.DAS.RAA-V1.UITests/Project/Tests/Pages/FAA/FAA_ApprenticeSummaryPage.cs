using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_ApprenticeSummaryPage : BasePage
    {
        protected override string PageTitle => _dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RAADataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By Apply => By.Id("apply-button");
        

        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAADataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_ApplicationForm ApplyForApprenticeship()
        {
            _formCompletionHelper.Click(Apply);
            return new FAA_ApplicationForm(_context);
        }
    }
}
