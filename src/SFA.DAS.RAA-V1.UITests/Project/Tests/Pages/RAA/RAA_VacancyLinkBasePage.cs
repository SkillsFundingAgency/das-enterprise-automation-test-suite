using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_VacancyLinkBasePage : RAA_PreviewBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By RespondToCandidateLink => By.LinkText("Respond to candidates");

        public RAA_VacancyLinkBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_CloseVacancyPage CloseVacancy()
        {
            formCompletionHelper.ClickLinkByText("Close this vacancy");
            return new RAA_CloseVacancyPage(_context);
        }

        public RAA_ChangeVacancyDatesPage ChangeVacancyDates()
        {
            formCompletionHelper.ClickLinkByText("Change vacancy dates");
            return new RAA_ChangeVacancyDatesPage(_context);
        }

        public RAA_IncreaseVacancyWagePage IncreaseWage()
        {
            formCompletionHelper.ClickLinkByText("Increase wage");
            return new RAA_IncreaseVacancyWagePage(_context);
        }

        public RAA_ShareApplicationsPage ShareApplications()
        {
            formCompletionHelper.ClickLinkByText("Share applications");
            return new RAA_ShareApplicationsPage(_context);
        }

        public RAA_ResponceToCandidatePage RespondToCandidates()
        {
            formCompletionHelper.ClickLinkByText("Respond to candidates");
            return new RAA_ResponceToCandidatePage(_context);
        }

        public RAA_ReadyToArchiveVacancyPage ArchiveVacancyAndRespondToCandidates()
        {
            formCompletionHelper.ClickLinkByText("Archive vacancy");
            return new RAA_ReadyToArchiveVacancyPage(_context);
        }

        public RAA_ArchiveVacancyPage ArchiveVacancy()
        {
            formCompletionHelper.ClickLinkByText("Archive vacancy");
            return new RAA_ArchiveVacancyPage(_context);
        }

        public bool IsRespondToCandidateLinkDisplayed()
        {
            return pageInteractionHelper.IsElementDisplayed(RespondToCandidateLink);
        }
    }
}
