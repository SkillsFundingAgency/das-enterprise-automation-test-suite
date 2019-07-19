using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class YourESFAAgreementPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

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
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
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