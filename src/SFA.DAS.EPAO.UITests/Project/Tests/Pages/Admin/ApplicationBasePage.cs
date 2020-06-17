using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class ApplicationBasePage : EPAOAdmin_BasePage
    {
        protected By NewTab => By.CssSelector("#tab_new");
        protected By InProgressTab => By.CssSelector("#tab_in-progress");
        protected By FeedbackTab => By.CssSelector("#tab_feedback");
        protected By ApprovedTab => By.CssSelector("#tab_approved");

        public ApplicationBasePage(ScenarioContext context) : base(context) => VerifyPage();
        
        public new StaffDashboardPage ReturnToDashboard() => base.ReturnToDashboard();

        protected void GoToApplicationOverviewPage(By by)
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));
            formCompletionHelper.ClickLinkByText(objectContext.GetApplyOrganisationName());
        }
    }
}