using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class AreYouSureBasePage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public VacancyReferencePage SelectYes()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new VacancyReferencePage(context);
        }
    }
}
