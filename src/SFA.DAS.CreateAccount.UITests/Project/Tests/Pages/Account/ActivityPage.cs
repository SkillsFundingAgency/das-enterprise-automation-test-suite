using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class ActivityPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Activity";
        private const string AdditionalTitleText = "A timeline of all the activity on your account.";
        private By _additionalTitleText = By.XPath("//p[@class=\'lede\']");
        private By _activityPageText = By.XPath("//p[@class=\'activity\']");

        public ActivityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
            IsAdditionalTitleTextPresented();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void IsAdditionalTitleTextPresented()
        {
            Assert.True(_pageInteractionHelper.GetText(_additionalTitleText).Contains(AdditionalTitleText));
        }

        public string GetAllActivityText()
        {
            return _pageInteractionHelper.GetTextFromElementsGroup(_activityPageText);
        }
    }
}