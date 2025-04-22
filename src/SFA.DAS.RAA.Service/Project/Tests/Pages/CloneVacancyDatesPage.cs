using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class CloneVacancyDatesPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Does the new advert have the same closing date and start date?" : "Does the new vacancy have the same closing date and start date?";
        
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public ConfimCloneVacancyDatePage SelectYes()
        {
            SelectRadioOptionByForAttribute("change-dates-yes");
            Continue();
            return new ConfimCloneVacancyDatePage(context);
        }
    }
}
