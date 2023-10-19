using SFA.DAS.RAA_V2.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WageTypePage : Raav2BasePage
    {
        protected override string PageTitle => "How much will the apprentice be paid?";

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
            if (wageType == RAAV2Const.NationalMinWages) SelectNationalMinimumWage();

            else if (wageType == RAAV2Const.FixedWageType) SelectFixedWageType();

            else SelectNationalMinimumWageForApprentices();
        }

        private void SelectNationalMinimumWage() => SelectRadioOptionByForAttribute("wage-type-national-minimum-wage");

        private void SelectFixedWageType() => SelectRadioOptionByForAttribute("wage-type-fixed");

        private void SelectNationalMinimumWageForApprentices() => SelectRadioOptionByForAttribute("wage-type-national-minimum-wage-for-apprentices");
    }
}
