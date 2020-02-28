using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class WhatIsAnApprenticeshipPage : CampaingnsBasePage
    {
        protected override string PageTitle => "WHAT IS AN APPRENTICESHIP?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By RealStories => By.CssSelector("a[href*='real-stories']");

        public WhatIsAnApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RealStoriesPage NavigateToRealStoriesPage()
        {
            formCompletionHelper.ClickElement(RealStories);
            return new RealStoriesPage(_context);
        }
    }
}
