using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class WageTypePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How much would you like to pay the apprentice?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By WageAdditionalInformation => By.CssSelector("#WageAdditionalInformation");

        private By FixedWageYearlyAmount => By.CssSelector("#FixedWageYearlyAmount");

        public WageTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public PreviewYourVacancyPage SelectNationalMinimumWage()
        {
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");
            return ContinueToPreviewYourVacancyPage();
        }
        
        public PreviewYourVacancyPage SelectNationalMinimumWageForApprentices()
        {
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage-for-apprentices");
            return ContinueToPreviewYourVacancyPage();
        }
        
        public PreviewYourVacancyPage SelectFixedWageType()
        {
            SelectRadioOptionByForAttribute("wage-type-fixed");
            formCompletionHelper.EnterText(FixedWageYearlyAmount, dataHelper.FixedWageYearlyAmount);
            return ContinueToPreviewYourVacancyPage();
        }

        private PreviewYourVacancyPage ContinueToPreviewYourVacancyPage()
        {
            formCompletionHelper.EnterText(WageAdditionalInformation, dataHelper.OptionalMessage);
            Continue();
            return new PreviewYourVacancyPage(_context);
        }
    }
}
