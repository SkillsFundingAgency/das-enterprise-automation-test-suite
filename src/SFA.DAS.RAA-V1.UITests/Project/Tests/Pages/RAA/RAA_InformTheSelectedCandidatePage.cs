using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_InformTheSelectedCandidatePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Inform the selected candidates";

        private By UnSuccessfulReason => By.CssSelector("#UnSuccessfulReason");

        public RAA_InformTheSelectedCandidatePage(ScenarioContext context) : base(context) { }

        public RAA_InformTheCandidatePreviewPage SendFeedback()
        {
            formCompletionHelper.EnterText(UnSuccessfulReason ,rAAV1DataHelper.OptionalMessage);

            formCompletionHelper.ClickButtonByText("Send feedback");

            return new RAA_InformTheCandidatePreviewPage(_context);
        }
    }
}
