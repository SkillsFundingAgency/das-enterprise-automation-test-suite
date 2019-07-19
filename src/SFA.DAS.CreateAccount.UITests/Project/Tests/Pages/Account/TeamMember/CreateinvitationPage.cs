using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class CreateInvitationPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "Email")] private IWebElement _emailInput;
        [FindsBy(How = How.Id, Using = "Name")] private IWebElement _nameInput;
        [FindsBy(How = How.Id, Using = "send_invitation")] private IWebElement _submitButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio1\"]")] private IWebElement _asViewerRadioButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio2\"]")] private IWebElement _asApprenticesAndViewerRadioButton;
        [FindsBy(How = How.CssSelector, Using = "[for=\"radio3\"]")] private IWebElement _asManagingRadioButton;

        public CreateInvitationPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(WebBrowserDriver, _emailInput);
        }

        internal CreateInvitationPage InputEmail(string email)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _emailInput, email);
            return this;
        }

        internal CreateInvitationPage InputMemberName(string name)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _nameInput, name);
            return this;
        }

        internal CreateInvitationPage SetMemberAsViewer()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _asViewerRadioButton);
            return this;
        }

        internal CreateInvitationPage SetMemberAsApprentices()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _asApprenticesAndViewerRadioButton);
            return this;
        }

        internal CreateInvitationPage SetMemberAsManaging()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _asManagingRadioButton);
            return this;
        }

        internal YourTeamPage Submit()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _submitButton);
            return new YourTeamPage(WebBrowserDriver);
        }
    }
}