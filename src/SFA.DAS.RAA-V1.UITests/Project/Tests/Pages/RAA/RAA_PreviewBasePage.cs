using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_PreviewBasePage : RAA_HeaderSectionBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_PreviewBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_VacancyReferencePage ClickSubmitForApprovalButton()
        {
            formCompletionHelper.ClickButtonByText("Submit for approval");
            return new RAA_VacancyReferencePage(_context);
        }
    }
}
