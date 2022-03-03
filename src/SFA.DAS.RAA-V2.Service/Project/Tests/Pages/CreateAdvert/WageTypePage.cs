using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WageTypePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How much would you like to pay the apprentice?";

        private By WageAdditionalInformation => By.CssSelector("#WageAdditionalInformation");

        private By FixedWageYearlyAmount => By.CssSelector("#FixedWageYearlyAmount");

        public WageTypePage(ScenarioContext context) : base(context) { }

        public SubmitNoOfPositionsPage SelectNationalMinimumWageAndGoToNoOfPositions()
        {
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");
            Continue();
            return new SubmitNoOfPositionsPage(context);
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
            formCompletionHelper.EnterText(FixedWageYearlyAmount, rAAV2DataHelper.FixedWageYearlyAmount);
            return ContinueToPreviewYourVacancyPage();
        }

        private PreviewYourVacancyPage ContinueToPreviewYourVacancyPage()
        {
            formCompletionHelper.EnterText(WageAdditionalInformation, rAAV2DataHelper.OptionalMessage);
            Continue();
            pageInteractionHelper.WaitforURLToChange("part1-complete");
            return new PreviewYourVacancyPage(context);
        }
    }
}
