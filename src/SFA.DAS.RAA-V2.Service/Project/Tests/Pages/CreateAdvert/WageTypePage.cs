using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WageTypePage : Raav2BasePage
    {
        protected override string PageTitle => "How much will the apprentice be paid?";

        private static By WageAdditionalInformation => By.CssSelector("#WageAdditionalInformation");

        private static By FixedWageYearlyAmount => By.CssSelector("#FixedWageYearlyAmount");

        public WageTypePage(ScenarioContext context) : base(context) { }

        public ExtraInformationAboutPayPage ChooseWage(string wageType)
        {
            return wageType switch
            {
                RAAV2Const.NationalMinWages => SelectNationalMinimumWageAndGoToNoExtraPayInformation(),
                RAAV2Const.FixedWageType => SelectFixedWageTypeAndGoToNoOfPositions(),
                _ => SelectNationalMinimumWageForApprenticesAndGoToNoOfPositions(),
            };
            ;
        }

        private ExtraInformationAboutPayPage SelectNationalMinimumWageAndGoToNoExtraPayInformation()
        {  
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");
            return GoToExtraInformationPage();
        }
        private ExtraInformationAboutPayPage SelectFixedWageTypeAndGoToNoOfPositions()
        {
            SelectRadioOptionByForAttribute("wage-type-fixed");
            formCompletionHelper.EnterText(FixedWageYearlyAmount, rAAV2DataHelper.FixedWageYearlyAmount);
            return GoToExtraInformationPage();
        }

        private ExtraInformationAboutPayPage SelectNationalMinimumWageForApprenticesAndGoToNoOfPositions()
        {
            SelectRadioOptionByForAttribute("wage-type-national-minimum-wage-for-apprentices");
            return GoToExtraInformationPage();
        }

        private ExtraInformationAboutPayPage GoToExtraInformationPage()
        {
            Continue();
            
            return new ExtraInformationAboutPayPage(context);
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
