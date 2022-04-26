using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class CloneVacancyDatesPage : Raav2BasePage
    {
        protected override string PageTitle => "Does the new advert have the same closing date and start date?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public CloneVacancyDatesPage(ScenarioContext context) : base(context) { }

        public ConfimCloneVacancyDatePage SelectYes()
        {
            SelectRadioOptionByForAttribute("change-dates-yes");
            Continue();
            return new ConfimCloneVacancyDatePage(context);
        }
    }
}
