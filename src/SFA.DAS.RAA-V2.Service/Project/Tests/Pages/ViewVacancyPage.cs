using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ViewVacancyPage : VerifyDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector("#vacancy-header");

        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override By EmployerName => By.CssSelector(".govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private By WageType => By.CssSelector(".govuk-list .govuk-body");

        protected override By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

        public ViewVacancyPage(ScenarioContext context) : base(context) { }
        
        public void VerifyWageType(string wageType)
        {
            string wageAmount;
            switch (wageType)
            {
                case "National Minimum Wage":
                    wageAmount = rAAV2DataHelper.NationalMinimumWage;
                    break;
                case "Fixed Wage Type":
                    wageAmount = rAAV2DataHelper.FixedWageForApprentices;
                    break;
                default:
                    wageAmount = rAAV2DataHelper.NationalMinimumWageForApprentices;
                    break;
            };

            VerifyPage(WageType, wageAmount);
        }

        public new ViewVacancyPage VerifyEmployerName()
        {
            base.VerifyEmployerName();
            return this;
        }

        public new ViewVacancyPage VerifyDisabilityConfident()
        {
            base.VerifyDisabilityConfident();
            return this;
        }
    }
}
