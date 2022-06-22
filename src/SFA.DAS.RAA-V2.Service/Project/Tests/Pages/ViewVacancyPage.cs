using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ViewVacancyPage : VerifyDetailsBasePage
    {
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override By EmployerName => By.CssSelector(".govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private By WageType => By.CssSelector(".govuk-grid-column-one-third .govuk-body");
        private By EmployerWageType => By.CssSelector(".govuk-list .govuk-body");

        protected override By DisabilityConfident => By.CssSelector("img.app-disability-confident-logo");

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

            VerifyElement(WageType, wageAmount);
        }
        public void VerifyEmployerWageType(string wageType)
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

            VerifyElement(EmployerWageType, wageAmount);
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
