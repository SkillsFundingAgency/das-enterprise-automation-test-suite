using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ViewVacancyPage : BasePage
    {
        protected override By PageHeader => By.CssSelector("#vacancy-header");

        protected override string PageTitle => _titleDatahelper.VacancyTitle;

        private By EmployerName => By.CssSelector(".govuk-caption-xl");

        private By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _titleDatahelper;
        #endregion

        public ViewVacancyPage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _titleDatahelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public ViewVacancyPage VerifyEmployerName()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
            return this;
        }

        public ViewVacancyPage VerifyDisabilityConfident()
        {
            VerifyPage(DisabilityConfident);
            return this;
        }
    }
}
