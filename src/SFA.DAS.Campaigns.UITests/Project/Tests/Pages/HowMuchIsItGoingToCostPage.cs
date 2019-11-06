using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{

    public class HowMuchIsItGoingToCostPage : BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Constants
        private const string ExpectedHowMuchIsItGoingToCostHeader = "HOW MUCH IS IT GOING TO COST?";
        #endregion

        #region Page Objects Elements
        private readonly By _howMuchIsItGoingToCostHeader = By.ClassName("heading-xl");

        #endregion


        public HowMuchIsItGoingToCostPage(ScenarioContext context): base(context)
        {
           _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        public void CheckThePageTitleForHowMuchIsItGoingToCost()
        {
          _pageInteractionHelper.VerifyText( _howMuchIsItGoingToCostHeader, ExpectedHowMuchIsItGoingToCostHeader );
        }
    }
}