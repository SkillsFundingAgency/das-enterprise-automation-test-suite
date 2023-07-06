
namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    internal class ApprenticeshipServiceEmployerSupportToolPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Apprenticeship service employer support tool";
        private static By StartNowButton => By.CssSelector(".govuk-button--start");

        public ApprenticeshipServiceEmployerSupportToolPage(ScenarioContext context) : base(context) => VerifyPage();
        
        public IdamsPage ClickStartNowButton() 
        {
           formCompletionHelper.Click(StartNowButton);

            return new IdamsPage(context);
        }
    }
}
