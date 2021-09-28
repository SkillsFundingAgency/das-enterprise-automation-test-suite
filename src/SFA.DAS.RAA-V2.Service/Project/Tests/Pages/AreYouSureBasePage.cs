using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class AreYouSureBasePage : RAAV2CSSBasePage
    {
        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private readonly ScenarioContext _context;

        public AreYouSureBasePage(ScenarioContext context) : base(context) => _context = context;

        public VacancyReferencePage SelectYes()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new VacancyReferencePage(_context);
        }
    }
}
