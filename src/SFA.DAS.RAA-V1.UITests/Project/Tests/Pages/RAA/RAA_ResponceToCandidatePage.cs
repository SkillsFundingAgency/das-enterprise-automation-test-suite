using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ResponceToCandidatePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Select the candidates";

        private By ApplicationCheckbox => By.CssSelector("input[type=checkbox]");

        public RAA_ResponceToCandidatePage(ScenarioContext context) : base(context) { }

        public RAA_InformTheSelectedCandidatePage ConfirmAndContinue()
        {
            formCompletionHelper.Click(ApplicationCheckbox);

            formCompletionHelper.ClickButtonByText("Confirm and continue");

            return new RAA_InformTheSelectedCandidatePage(_context);
        }
    }
}
