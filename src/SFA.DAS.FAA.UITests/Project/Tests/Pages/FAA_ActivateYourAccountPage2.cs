using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage2(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Tell us more about you";

        private static By SaveAndContinue => By.Id("save-continue-button");
        private static By SkipLink => By.Id("skip-link");

        public FAA_ApprenticeSearchPage ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinue);
            pageInteractionHelper.WaitforURLToChange("apprenticeshipsearch");
            return new FAA_ApprenticeSearchPage(context);
        }

        public FAA_ApprenticeSearchPage ClickSkipLink()
        {
            formCompletionHelper.Click(SkipLink);
            return new FAA_ApprenticeSearchPage(context);
        }
    }
}
