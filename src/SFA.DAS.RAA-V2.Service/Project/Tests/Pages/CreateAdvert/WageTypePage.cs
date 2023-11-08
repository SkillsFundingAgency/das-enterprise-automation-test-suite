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

        public ExtraInformationAboutPayPage ChooseWage_Employer(string wageType)
        {
            ChooseWage(wageType);

            Continue();

            return new ExtraInformationAboutPayPage(context);
        }

        public SubmitNoOfPositionsPage ChooseWage_Provider(string wageType)
        {
            ChooseWage(wageType);

            Continue();

            return new SubmitNoOfPositionsPage(context);
        }
        private void ChooseWage(string wageType)
        {
            if (wageType == RAAV2Const.NationalMinWages) EnterNationalMinWages();

            else if (wageType == RAAV2Const.FixedWageType) EnterFixedWageType();
            else if (wageType == RAAV2Const.SetAsCompetitive)
            {
                EnterSetAsCompetitive();
                ExtraInformationAboutWage();
            }

            else EnterNationalMinimumWageForApprentices();
        }

        public CompetitiveWagePage ExtraInformationAboutWage()
        {
            Continue();
            SubmitYes();

            return new CompetitiveWagePage(context);
        }


        public PreviewYourVacancyPage SelectNationalMinimumWage()
        {
            EnterNationalMinWages();
            return ContinueToPreviewYourVacancyPage();
        }

        public PreviewYourVacancyPage SelectNationalMinimumWageForApprentices()
        {
            EnterNationalMinimumWageForApprentices();
            return ContinueToPreviewYourVacancyPage();
        }

        public PreviewYourVacancyPage SelectFixedWageType()
        {
            EnterFixedWageType();
            return ContinueToPreviewYourVacancyPage();
        }

        public PreviewYourVacancyPage SelectSetAsCompetitive()
        {
            EnterSetAsCompetitive();
            return ContinueToPreviewYourVacancyPage();
        }
        private PreviewYourVacancyPage ContinueToPreviewYourVacancyPage()
        {
            formCompletionHelper.EnterText(WageAdditionalInformation, rAAV2DataHelper.OptionalMessage);
            Continue();
            pageInteractionHelper.WaitforURLToChange("part1-complete");
            return new PreviewYourVacancyPage(context);
        }

        private void EnterNationalMinWages() => SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");

        private void EnterNationalMinimumWageForApprentices() => SelectRadioOptionByForAttribute("wage-type-national-minimum-wage-for-apprentices");

        private void EnterSetAsCompetitive() => SelectRadioOptionByForAttribute("wage-type-set-as-competitive");


        private void EnterFixedWageType()
        {
            SelectRadioOptionByForAttribute("wage-type-fixed");
            
            formCompletionHelper.EnterText(FixedWageYearlyAmount, rAAV2DataHelper.FixedWageYearlyAmount);
        }

        private static By SelectYesRadioButton => By.CssSelector("#competitive-salary-type-national-minimum-wage-or-above");
        public CompetitiveWagePage SubmitYes()
        {
            SelectYesIfSalaryIsAboveNationalMinWage();
            return new CompetitiveWagePage(context);
        }

        private void SelectYesIfSalaryIsAboveNationalMinWage()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectYesRadioButton);
        }
    }
}
