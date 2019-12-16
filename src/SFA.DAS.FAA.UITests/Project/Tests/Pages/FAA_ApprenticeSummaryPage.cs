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
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ApplyButton => By.Id("apply-button");

        private By ViewApplicationLink => By.Id("view-application-link");

        private By EmployerName => By.Id("vacancy-subtitle-employer-name");

        private By EmployerNameInAboutTheEmployerSection => By.Id("vacancy -employer-name");

        private By EmployerLocation => By.CssSelector("div[itemprop='address']");


        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
            if (!_objectContext.IsRAAV1()) { VerifyEmployerName(); }
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

        private void VerifyEmployerName()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }
    }
}
