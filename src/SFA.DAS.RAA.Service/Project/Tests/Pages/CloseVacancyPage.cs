using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class CloseVacancyPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Are you sure you want to close this advert on Find an apprenticeship?" : "Are you sure you want to close this vacancy on Find an apprenticeship?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public ManageCloseVacancyPage YesCloseThisVacancy()
        {
            SelectRadioOptionByForAttribute("close-yes");
            Continue();
            return new ManageCloseVacancyPage(context);
        }
    }
}
