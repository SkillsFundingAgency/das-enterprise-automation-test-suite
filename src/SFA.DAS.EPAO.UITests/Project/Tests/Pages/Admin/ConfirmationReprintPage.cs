using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ConfirmationReprintPage : ConfirmationAmendReprintBasePage
    {
        protected override string PageTitle => "Reprint certificate";

        #region Helpers and Context

        #endregion

        public ConfirmationReprintPage(ScenarioContext context) : base(context) { }
    }
}