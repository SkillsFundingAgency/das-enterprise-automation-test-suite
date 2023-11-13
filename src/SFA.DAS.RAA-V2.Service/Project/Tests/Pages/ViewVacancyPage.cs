using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ViewVacancyPage : VerifyDetailsBasePage
    {
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override string AccessibilityPageTitle => "Employer and provider view vacancy page";

        protected override By EmployerName => By.CssSelector(".govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private static By WageType => By.CssSelector(".govuk-grid-column-one-third .govuk-body");

        private static By EmployerWageType => By.CssSelector(".govuk-grid-column-one-third .govuk-body");

        protected override By DisabilityConfident => By.CssSelector("img.app-disability-confident-logo");

        public ViewVacancyPage(ScenarioContext context) : base(context) { }
        
        public void VerifyWageType(string wageType) => VerifyWageAmount(WageType, wageType);

        public void VerifyEmployerWageType(string wageType) => VerifyWageAmount(EmployerWageType, wageType);

        private string GetWageAmount(string wageType)
        {
            return wageType switch
            {
                RAAV2Const.NationalMinWages => rAAV2DataHelper.NationalMinimumWage,
                RAAV2Const.FixedWageType => rAAV2DataHelper.FixedWageForApprentices,
                RAAV2Const.SetAsCompetitive => rAAV2DataHelper.SetAsCompetitive,
                _ => rAAV2DataHelper.NationalMinimumWageForApprentices,
            };
        }

        private void VerifyWageAmount(By by, string wageType) => VerifyElement(by, GetWageAmount(wageType));

        public new ViewVacancyPage VerifyDisabilityConfident()
        {
            base.VerifyDisabilityConfident();
            return this;
        }
    }
}
