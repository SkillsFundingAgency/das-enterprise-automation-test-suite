using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EditVacancyConfirmationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => $"The vacancy '{dataHelper.VacancyTitle}' has been updated.";

        private By Info => By.CssSelector(".info-summary");

        public EditVacancyConfirmationPage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElements(Info));
    }
}
