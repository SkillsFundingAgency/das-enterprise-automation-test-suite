using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class InvitationsPage: BasePage
    {
        [FindsBy(How = How.Id, Using = "invitationId")] private IWebElement _acceptButton;

        public InvitationsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }
        
        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(_acceptButton);
        }

        public void AcceptTheLastInvitation()
        {
            formCompletionHelper.ClickElement(_acceptButton);
        }
    }
}