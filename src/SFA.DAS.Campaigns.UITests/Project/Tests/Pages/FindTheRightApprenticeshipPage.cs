using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    internal class FindTheRightApprenticeshipPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constants
        private const string ExpectedTheRightApprenticeshipHeader = "FIND THE RIGHT APPRENTICESHIP";
        #endregion

        #region Page Objects Elements
        private readonly By _findTheRightApprenticeshipHeader = By.ClassName("heading-xl");
        private readonly By _apprenticeshipSearchField = By.Id("Keywords");
        private readonly By _employerApprenticeshipSearchButton =By.Id("employer-apprenticeship-search");
    
        #endregion

        public FindTheRightApprenticeshipPage(ScenarioContext context): base(context)
        {
             _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

        }
        public FindTheRightApprenticeshipResultPage ClickOnTheFindTheRightApprenticeshipButton()
        {
            _formCompletionHelper.ClickElement(_employerApprenticeshipSearchButton);
            return new FindTheRightApprenticeshipResultPage(_context);
        }

        public FindTheRightApprenticeshipPage CheckTheRightApprenticeshipPageHeader()
        {
            _pageInteractionHelper.VerifyText(_findTheRightApprenticeshipHeader,ExpectedTheRightApprenticeshipHeader);
            return new FindTheRightApprenticeshipPage(_context);
        }

    }
}