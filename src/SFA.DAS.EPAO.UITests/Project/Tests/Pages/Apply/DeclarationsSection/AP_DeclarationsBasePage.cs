namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection
{
    public class AP_DeclarationsBasePage : EPAOApply_BasePage
    {
        protected override string PageTitle => "Declarations";

        #region Locators
        private static By NameAndJobTitleLink => By.LinkText("Name and job title");
        #endregion

        public AP_DeclarationsBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_DAD_1_AuthoriserDetailsPage ClickNameAndJobTitleLinkInDeclarationsBasePage()
        {
            formCompletionHelper.Click(NameAndJobTitleLink);
            return new AP_DAD_1_AuthoriserDetailsPage(context);
        }
    }
}
