using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
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


    public class RAA_ArchiveVacancyPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Archive vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_ArchiveVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_ArchivedVacancyPreviewPage Confirm()
        {
            formCompletionHelper.ClickButtonByText("Confirm");

            return new RAA_ArchivedVacancyPreviewPage(_context);
        }
    }


    public class RAA_ArchivedVacancyPreviewPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary > p");

        protected override string PageTitle => "This vacancy has been archived";

        public RAA_ArchivedVacancyPreviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }


    


    public class RAA_ReadyToArchiveVacancyPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Are you ready to archive this vacancy?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_ReadyToArchiveVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_ResponceToCandidatePage RespondToRemainingCandidates()
        {
            formCompletionHelper.ClickButtonByText("Respond to remaining candidates");

            return new RAA_ResponceToCandidatePage(_context);
        }
    }
}
