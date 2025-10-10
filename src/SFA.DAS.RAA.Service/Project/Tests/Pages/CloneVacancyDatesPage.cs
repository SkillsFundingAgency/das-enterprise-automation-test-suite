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
            StoreMultipleLocationsFlag();
            return new ConfimCloneVacancyDatePage(context);
        }

        public void StoreMultipleLocationsFlag()
        {
            var dtElements = pageInteractionHelper.FindElements(By.CssSelector("dt.app-summary-list__key"));
            bool multipleLocations = false;
            foreach (var dt in dtElements)
            {
                if (dt.Text.Trim() == "Locations")
                {
                    multipleLocations = true;
                    break;
                }
            }
            context["multipleLocations"] = multipleLocations;
        }
    }
}
