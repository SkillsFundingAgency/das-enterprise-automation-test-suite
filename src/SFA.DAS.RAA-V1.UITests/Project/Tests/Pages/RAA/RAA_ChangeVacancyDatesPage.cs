using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ChangeVacancyDatesPage : RAA_ChangeVacancyDatesBasePage
    {
        protected override string PageTitle => "Change vacancy dates";

        #region Helpers and Context
        
        #endregion

        public RAA_ChangeVacancyDatesPage(ScenarioContext context) : base(context) { }

        public RAA_ChangeVacancyDatePreviewPage SaveAndContinue()
        {
            EnterVacancyClosingDate()
            .EnterPossibleStartDate();
            formCompletionHelper.ClickButtonByText("Save and return");
            return new RAA_ChangeVacancyDatePreviewPage(context);

        }
        private new RAA_ChangeVacancyDatesPage EnterVacancyClosingDate()
        {
            base.EnterVacancyClosingDate();
            return this;
        }

        private new RAA_ChangeVacancyDatesPage EnterPossibleStartDate()
        {
            base.EnterPossibleStartDate();
            return this;
        }
    }
}
