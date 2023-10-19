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

        public SubmitNoOfPositionsPage ChooseWage_Provider(string wageType)
        {
            ChooseWage(wageType);

            Continue();

            return new SubmitNoOfPositionsPage(context);
        }

        public ExtraInformationAboutPayPage ChooseWage_Employer(string wageType)
        {
            ChooseWage(wageType);

            Continue();

            return new ExtraInformationAboutPayPage(context);
        }

        private void ChooseWage(string wageType)
        {
            if (wageType == RAAV2Const.NationalMinWages) SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");

            else if (wageType == RAAV2Const.FixedWageType) SelectRadioOptionByForAttribute("wage-type-fixed");

            else SelectRadioOptionByForAttribute("wage-type-national-minimum-wage-for-apprentices");
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
