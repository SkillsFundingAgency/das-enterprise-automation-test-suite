using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_VacancyPreviewPage : ApproveVacancyBasePage
    {
        protected override string PageTitle => _vacancyTitleDatahelper.VacancyTitle;

        #region Helpers and Context
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;
        #endregion

        protected override By EmployerName => By.ClassName("govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.XPath("//div[@id='EmployerName']/p");

        protected override By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

        public Reviewer_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _vacancyTitleDatahelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public new Reviewer_VacancyPreviewPage VerifyEmployerName()
        {
            base.VerifyEmployerName();
            return this;
        }

        public new Reviewer_VacancyPreviewPage VerifyDisabilityConfident()
        {
            base.VerifyDisabilityConfident();
            return this;
        }
    }
}
