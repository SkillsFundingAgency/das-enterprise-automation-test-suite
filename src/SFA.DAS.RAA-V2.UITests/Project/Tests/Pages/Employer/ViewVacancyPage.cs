using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ViewVacancyPage : VerifyDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector("#vacancy-header");

        protected override string PageTitle => _titleDatahelper.VacancyTitle;

        protected override By EmployerName => By.CssSelector(".govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.CssSelector("div.govuk-grid-column-two-thirds > p:nth-child(4)");

        private By WageType => By.CssSelector(".govuk-list .govuk-body");

        protected override By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

        #region Helpers and Context
        private readonly VacancyTitleDatahelper _titleDatahelper;
        #endregion

        public ViewVacancyPage(ScenarioContext context) : base(context)
        {
            _titleDatahelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public void VerifyWageType(string wageType)
        {
            string wageAmount;
            switch (wageType)
            {
                case "National Minimum Wage":
                    wageAmount = rAAV2EmployerdataHelper.NationalMinimumWage;
                    break;
                case "Fixed Wage Type":
                    wageAmount = rAAV2EmployerdataHelper.FixedWageForApprentices;
                    break;
                default:
                    wageAmount = rAAV2EmployerdataHelper.NationalMinimumWageForApprentices;
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
