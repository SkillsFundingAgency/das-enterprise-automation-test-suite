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

        [FindsBy(How = How.Id, Using = "Email")] private IWebElement _emailInput;
        [FindsBy(How = How.Id, Using = "Name")] private IWebElement _nameInput;
        [FindsBy(How = How.Id, Using = "send_invitation")] private IWebElement _submitButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio1\"]")] private IWebElement _asViewerRadioButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio2\"]")] private IWebElement _asApprenticesAndViewerRadioButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio3\"]")] private IWebElement _asManagingRadioButton;

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