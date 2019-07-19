using System;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class CohortsLandingPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"column-one-half bingo-background block-one clickable\"]//h2")] private IWebElement _toBeSentCount;

        public CohortsLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public int GetWaitingToBeSent()
        {
            var count = _toBeSentCount.Text;
            return Convert.ToInt32(count);
        }
    }
}