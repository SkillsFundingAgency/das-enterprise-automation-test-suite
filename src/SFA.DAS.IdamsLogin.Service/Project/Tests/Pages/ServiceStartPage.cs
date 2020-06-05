using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class ServiceStartPage : IdamsLoginBasePage
    {
        protected override string PageTitle => "ESFA admin services";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartNow => By.CssSelector(".govuk-button--start");

        public ServiceStartPage(ScenarioContext context) : base(context) => _context = context;

        public IdamsPage ClickStartNow()
        {
            formCompletionHelper.ClickElement(StartNow);
            return new IdamsPage(_context);
        }
    }
}
