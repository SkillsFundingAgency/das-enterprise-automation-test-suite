using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class CloseVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to close this vacancy on Find an apprenticeship?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

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
            Continue();
            return new ManageCloseVacancyPage(_context);
        }
    }
}
