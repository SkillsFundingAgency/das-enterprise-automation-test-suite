using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ViewVacancyPage : BasePage
    {
        protected override By PageHeader => By.CssSelector("#vacancy-header");

        protected override string PageTitle => "Manage vacancy";

        private By EmployerName => By.CssSelector(".govuk-caption-xl");

        private By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private By EmployerLocation => By.CssSelector(".govuk-grid-column-one-half .govuk-list");


        private readonly ObjectContext _objectContext;

        public ViewVacancyPage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public ViewVacancyPage VerifyEmployerName()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
            return this;
        }

        public ViewVacancyPage VerifyEmployerLocation()
        {
            VerifyPage(EmployerLocation, _objectContext.GetEmployerLocation());
            return this;
        }
    }
}
