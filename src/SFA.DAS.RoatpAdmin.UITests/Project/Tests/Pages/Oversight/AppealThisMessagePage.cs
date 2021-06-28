using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AppealThisMessagePage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Enter the applicant's appeal message";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Message => By.Id("Message");

        private By UploadFileButton => By.CssSelector(".govuk-button--secondary");

        public AppealThisMessagePage(ScenarioContext context) : base(context) => _context = context;


        public ApplicationSummaryPage AppealThisApplication()
        {
            formCompletionHelper.EnterText(Message, "Appeal Message comments ");
            ChooseFile();
            formCompletionHelper.ClickElement(UploadFileButton);
            formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");
            return new ApplicationSummaryPage(_context);
        }

    }
}
