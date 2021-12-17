using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage2 : FAABasePage
    {
        protected override string PageTitle => "Tell us more about you";

        private By SaveAndContinue => By.Id("save-continue-button");
        private By SkipLink => By.Id("skip-link");

        public FAA_ActivateYourAccountPage2(ScenarioContext context) : base(context) { }

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
