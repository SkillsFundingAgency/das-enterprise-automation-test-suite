namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class ClosedVacancyPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "You can no longer apply for this apprenticeship";

        private static By ClosedVacancyTitle => By.CssSelector("h3[class='govuk-heading-m']");
        public string GetClosedVacancyTitle()
        {
            return pageInteractionHelper.FindElement(ClosedVacancyTitle).Text;
        }
    }
}
