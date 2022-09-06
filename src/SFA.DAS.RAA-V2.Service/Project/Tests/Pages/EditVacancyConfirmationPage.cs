using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyConfirmationPage : Raav2BasePage
    {
        protected override string PageTitle => $"The vacancy dates for “{rAAV2DataHelper.VacancyTitle}” have been updated.";

        private By Info => By.CssSelector(".info-summary");

        public EditVacancyConfirmationPage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElements(Info));
    }
}
