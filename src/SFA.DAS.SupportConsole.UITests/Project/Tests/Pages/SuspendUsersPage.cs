
namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SuspendUsersPage : ToolSupportBasePage
    {
        protected override string PageTitle => "Suspend users";

        #region Locators
        private static By SuspendUsersbtn => By.Id("okButton");
        private static By StatusColumn => By.CssSelector("#usersResultsTable tr td:nth-child(3)");
        #endregion

        public SuspendUsersPage(ScenarioContext context) : base(context) { }

        public SuspendUsersPage ClicSuspendUsersbtn()
        {
            formCompletionHelper.Click(SuspendUsersbtn);
            return this;
        }

        public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
    }

}
