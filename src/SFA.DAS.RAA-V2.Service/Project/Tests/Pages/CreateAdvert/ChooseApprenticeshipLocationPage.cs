using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ChooseApprenticeshipLocationPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "Where is the work experience placement" : "Where will the apprentice work?";

        private By AddressLine1 => By.CssSelector("#AddressLine1");

        private By Postcode => By.CssSelector("#Postcode");

        private By MenuItems => By.CssSelector(".ui-menu-item");

        public ChooseApprenticeshipLocationPage(ScenarioContext context) : base(context) { }

        public CreateAnApprenticeshipAdvertOrVacancyPage ChooseAddressAndGoToCreateApprenticeshipPage(bool isEmployerAddress)
        {
            if (isEmployerAddress) SelectRadioOptionByForAttribute("OtherLocation_1");
            else DifferentLocation();

            Continue();

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public ImportantDatesPage ChooseAddress(bool isEmployerAddress)
        {
            if (isEmployerAddress) SelectRadioOptionByForAttribute("OtherLocation_1");
            else DifferentLocation();

            Continue();

            pageInteractionHelper.WaitforURLToChange("dates");

            return new ImportantDatesPage(context);
        }

        private void DifferentLocation()
        {
            SelectRadioOptionByForAttribute("other-location");
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(Postcode, $"{rAAV2DataHelper.EmployerAddress} "); return pageInteractionHelper.FindElement(MenuItems); });
        }
    }
}
