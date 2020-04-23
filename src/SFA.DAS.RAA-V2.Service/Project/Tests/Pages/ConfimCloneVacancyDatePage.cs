using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfimCloneVacancyDatePage : BasePage
    {
        protected override string PageTitle => "Vacancy succesfully cloned";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Info => By.CssSelector(".info-summary");
        private By ChangeTitle => By.CssSelector("a[data-automation='link-employer-name']");        

        public ConfimCloneVacancyDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage(() => _pageInteractionHelper.FindElements(Info));
        }

        public VacancyTitlePage UpdateTitle()
        {
            _formCompletionHelper.Click(ChangeTitle);
            return new VacancyTitlePage(_context);
        }
    }
}
