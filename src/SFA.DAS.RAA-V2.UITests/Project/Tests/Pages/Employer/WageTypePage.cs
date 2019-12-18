using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class WageTypePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How much would you like to pay the apprentice?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By WageAdditionalInformation => By.CssSelector("#WageAdditionalInformation");

        public WageTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public PreviewYourVacancyPage SelectNationalMinimumWage()
        {
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");
            formCompletionHelper.EnterText(WageAdditionalInformation, dataHelper.OptionalMessage);
            Continue();
            return new PreviewYourVacancyPage(_context);
        }
    }
}
