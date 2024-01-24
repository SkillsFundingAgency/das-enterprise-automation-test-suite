using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ApplicationPreviewPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => vacancyTitledataHelper.VacancyTitle;

        #region Helpers and Context

        #endregion

        private By Notes => By.CssSelector("#Notes");

        private By RadioOptions => By.CssSelector("label.selection-button-radio");

        private By CandidateFeedback => By.CssSelector("#candidate-feedback");

        public RAA_ApplicationPreviewPage(ScenarioContext context) : base(context) { }

        public RAA_VacancySummaryPage ChangeStatus(string newstatus)
        {
            formCompletionHelper.EnterText(Notes, rAAV1DataHelper.OptionalMessage);

            string forAttribute = string.Empty;
            switch (true)
            {
                case bool _ when newstatus == "New":
                    forAttribute = "application-status-submitted";
                    break;
                case bool _ when newstatus == "In progress":
                    forAttribute = "application-status-inprogress";
                    break;
                case bool _ when newstatus == "Unsuccessful":
                    forAttribute = "application-status-unsuccessful";
                    break;
                case bool _ when newstatus == "Successful":
                    forAttribute = "application-status-successful";
                    break;
                default:
                    break;
            }

            formCompletionHelper.SelectRadioOptionByForAttribute(RadioOptions, forAttribute);

            formCompletionHelper.ClickButtonByText("Save and Continue");


            if (newstatus == "Successful")
            {
                formCompletionHelper.ClickButtonByText("Confirm and send");
                pageInteractionHelper.WaitforURLToChange("confirmsuccessfuldecision");
                formCompletionHelper.ClickButtonByText("Return to vacancy applications");
            }

            if (newstatus == "Unsuccessful")
            {
                formCompletionHelper.EnterText(CandidateFeedback, rAAV1DataHelper.OptionalMessage);
                formCompletionHelper.ClickButtonByText("Confirm and send");
                formCompletionHelper.ClickButtonByText("Return to vacancy applications");
            }

            return new RAA_VacancySummaryPage(context);
        }

    }
}
