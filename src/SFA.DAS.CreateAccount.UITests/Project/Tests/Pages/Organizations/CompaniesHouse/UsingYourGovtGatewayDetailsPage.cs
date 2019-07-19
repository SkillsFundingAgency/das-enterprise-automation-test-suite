using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class UsingYourGovtGatewayDetailsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Using your Government Gateway details";
        private By _agreeAndContinueButton = By.XPath("//*[contains(@id, 'agree_and_continue')]");

        public UsingYourGovtGatewayDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal SignInGovernmentPage Continue()
        {
            _formCompletionHelper.ClickElement(_agreeAndContinueButton);
            return new SignInGovernmentPage(_context);
        }
    }
}