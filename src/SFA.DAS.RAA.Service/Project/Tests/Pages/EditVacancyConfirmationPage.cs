using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class EditVacancyConfirmationPage : RaaBasePage
    {
        protected override string PageTitle => $"The vacancy dates for “{rAADataHelper.VacancyTitle}” have been updated.";

        protected override string AccessibilityPageTitle => "The vacancy dates for vacancy title have been updated";

        private static By Info => By.CssSelector(".info-summary");

        public EditVacancyConfirmationPage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElements(Info));
    }
}
