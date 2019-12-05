using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSummaryPage : BasePage
    {
        protected override string PageTitle => _dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ApplyButton => By.Id("apply-button");

        private By ViewApplicationLink => By.Id("view-application-link");


        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_YourApplicationPage View()
        {
            _formCompletionHelper.Click(ViewApplicationLink);
            return new FAA_YourApplicationPage(_context);
        }


        public FAA_ApplicationFormPage Apply()
        {
            _formCompletionHelper.Click(ApplyButton);
            return new FAA_ApplicationFormPage(_context);
        }
    }
}
