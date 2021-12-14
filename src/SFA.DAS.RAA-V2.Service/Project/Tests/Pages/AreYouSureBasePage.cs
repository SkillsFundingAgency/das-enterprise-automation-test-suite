using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class AreYouSureBasePage : RAAV2CSSBasePage
    {
        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public AreYouSureBasePage(ScenarioContext context) : base(context) { }

        public VacancyReferencePage SelectYes()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new VacancyReferencePage(context);
        }
    }
}
