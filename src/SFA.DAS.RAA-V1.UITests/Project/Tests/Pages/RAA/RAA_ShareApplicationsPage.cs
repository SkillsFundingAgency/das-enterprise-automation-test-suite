using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ShareApplicationsPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Select the applications you would like to share";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApplicationCheckbox => By.CssSelector("input[type=checkbox]");

        private By RecipientEmailAddress => By.CssSelector("#RecipientEmailAddress");

        private By OptionalMessage => By.CssSelector("#OptionalMessage");

        
        public RAA_ShareApplicationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_ShareApplicationPreviewPage Send()
        {
            formCompletionHelper.Click(ApplicationCheckbox);

            formCompletionHelper.EnterText(RecipientEmailAddress, rAAV1DataHelper.ShareApplicationEmail);

            formCompletionHelper.EnterText(OptionalMessage, rAAV1DataHelper.OptionalMessage);

            formCompletionHelper.ClickButtonByText("Send");

            return new RAA_ShareApplicationPreviewPage(_context);
        }
    }
}
