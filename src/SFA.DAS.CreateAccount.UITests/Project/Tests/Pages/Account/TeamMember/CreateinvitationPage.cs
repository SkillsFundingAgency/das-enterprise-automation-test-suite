using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class CreateInvitationPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _emailInput = By.Id("Email");
        private readonly By _nameInput = By.Id("Name");
        private readonly By _submitButton = By.Id("send_invitation");
        private readonly By _asViewerRadioButton = By.CssSelector("[for=\"radio1\"]");
        private readonly By _asApprenticesAndViewerRadioButton = By.CssSelector("[for=\"radio2\"]");
        private readonly By _asManagingRadioButton = By.CssSelector("[for=\"radio3\"]");

        public CreateInvitationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_emailInput);
        }

        internal CreateInvitationPage InputEmail(string email)
        {
            _formCompletionHelper.EnterText(_emailInput, email);
            return this;
        }

        internal CreateInvitationPage InputMemberName(string name)
        {
            _formCompletionHelper.EnterText(_nameInput, name);
            return this;
        }

        internal CreateInvitationPage SetMemberAsViewer()
        {
            _formCompletionHelper.SelectRadioButton(_asViewerRadioButton);
            return this;
        }

        internal CreateInvitationPage SetMemberAsApprentices()
        {
            _formCompletionHelper.SelectRadioButton(_asApprenticesAndViewerRadioButton);
            return this;
        }

        internal CreateInvitationPage SetMemberAsManaging()
        {
            _formCompletionHelper.SelectRadioButton(_asManagingRadioButton);
            return this;
        }

        internal YourTeamPage Submit()
        {
            _formCompletionHelper.ClickElement(_submitButton);
            return new YourTeamPage(_context);
        }
    }
}