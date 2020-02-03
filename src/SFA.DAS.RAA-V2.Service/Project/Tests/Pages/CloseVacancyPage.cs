using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class CloseVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to close this vacancy on Find an apprenticeship?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        private  By Continue => By.CssSelector("input[type='submit'][value='Continue']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CloseVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ManageCloseVacancyPage YesCloseThisVacancy()
        {
            SelectRadioOptionByForAttribute("close-yes");
            formCompletionHelper.Click(Continue);
            return new ManageCloseVacancyPage(_context);
        }
    }
}
