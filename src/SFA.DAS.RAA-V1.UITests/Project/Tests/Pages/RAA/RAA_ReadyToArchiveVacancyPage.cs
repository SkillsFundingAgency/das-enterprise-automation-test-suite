using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
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
