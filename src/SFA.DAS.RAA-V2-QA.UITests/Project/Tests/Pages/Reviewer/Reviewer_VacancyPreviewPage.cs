using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_VacancyPreviewPage(ScenarioContext context) : ApproveVacancyBasePage(context)
    {
        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override string AccessibilityPageTitle => "QA vacancy title page";

        protected override By EmployerName => By.ClassName("govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.XPath("//div[@id='EmployerName']/p");

        protected override By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

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
