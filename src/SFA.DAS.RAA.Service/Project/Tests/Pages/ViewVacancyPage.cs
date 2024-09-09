using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ViewVacancyPage(ScenarioContext context) : VerifyDetailsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l.faa-vacancy__title");

        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override string AccessibilityPageTitle => "Employer and provider view vacancy page";

        protected override By EmployerName => By.CssSelector(".govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private static By WageType => By.XPath("//div[@class='app-preview-wrap']//div[1]//dd[1]");

        private static By EmployerWageType => By.XPath("//div[@class='app-preview-wrap']//div[1]//dd[1]");

        protected override By DisabilityConfident => By.CssSelector("img[alt='Disability Confident']");

        public void VerifyWageType(string wageType) => VerifyWageAmount(WageType, wageType);

        public void VerifyEmployerWageType(string wageType) => VerifyWageAmount(EmployerWageType, wageType);

        private static string GetWageAmount(string wageType)
        {
            return wageType switch
            {
                RAAConst.NationalMinWages => RAADataHelper.NationalMinimumWage,
                RAAConst.FixedWageType => RAADataHelper.FixedWageForApprentices,
                RAAConst.SetAsCompetitive => RAADataHelper.SetAsCompetitive,
                _ => RAADataHelper.NationalMinimumWageForApprentices,
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
