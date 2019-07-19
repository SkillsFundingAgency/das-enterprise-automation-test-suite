using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class YourESFAAgreementPage : BasePage
    {
        private const string PageTitle = "Your ESFA agreement";
        private By _updateTheseDetailsLink = By.XPath("//a[contains(text(),\'Update these details\')]");

        public YourESFAAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public bool IsUpdateDetailsLinkPresent()
        {
            return _formCompletionHelper.IsElementDisplayed(_updateTheseDetailsLink);
        }

        public void ClickUpdateDetailsLink()
        {
            _formCompletionHelper.ClickElement(_updateTheseDetailsLink);
        }
    }
}