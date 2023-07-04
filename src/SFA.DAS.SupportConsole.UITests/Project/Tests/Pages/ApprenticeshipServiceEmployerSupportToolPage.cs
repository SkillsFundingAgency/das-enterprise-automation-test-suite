
namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    internal class ApprenticeshipServiceEmployerSupportToolPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Apprenticeship service employer support tool";
        private By StartNowButton => By.CssSelector(".govuk-button--start");



        public ApprenticeshipServiceEmployerSupportToolPage(ScenarioContext context) : base(context) { }
        

        public IdamsPage ClickStartNowButton() 
        {
            if(pageInteractionHelper.IsElementDisplayed(StartNowButton))
                formCompletionHelper.Click(StartNowButton);

            return new IdamsPage(context);
        }
    }
}
