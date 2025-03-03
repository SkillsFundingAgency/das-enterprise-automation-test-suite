using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ChooseApprenticeshipLocationPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Where is this apprenticeship available?";

        private static By Postcode => By.CssSelector("#Postcode");

        private static By MenuItems => By.CssSelector(".ui-menu-item");
        private static By SingleLocationRadoButton => By.CssSelector(".govuk-radios__input");

        public CreateAnApprenticeshipAdvertOrVacancyPage ChooseAddressAndGoToCreateApprenticeshipPage(bool isEmployerAddress)
        {
            if (isEmployerAddress) SelectRadioOptionByForAttribute("OneLocation");
            else DifferentLocation();

            Continue();

            formCompletionHelper.SelectRandomRadioOptionByLocator(SingleLocationRadoButton);
            
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
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(Postcode, $"{RAADataHelper.EmployerAddress} "); return pageInteractionHelper.FindElement(MenuItems); });
        }
    }
}
