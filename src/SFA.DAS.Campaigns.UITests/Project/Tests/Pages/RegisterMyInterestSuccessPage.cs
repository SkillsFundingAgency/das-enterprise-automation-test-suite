using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class RegisterMyInterestSuccessPage : BasePage
    {
                protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constants
        private const string ExpectedSuccessHeader = "SUCCESS";
        #endregion

        #region Page Objects Elements
        private readonly By __successHeader = By.ClassName("heading-l");
        private readonly By _firstNameField =By.XPath("(//input[@id='FirstName'])[2]");
        
        #endregion

        public RegisterMyInterestSuccessPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();
        }
        public void ValidateTheSuccessHeader()
            {
              _pageInteractionHelper.VerifyText(__successHeader,ExpectedSuccessHeader);

            }
    }
}