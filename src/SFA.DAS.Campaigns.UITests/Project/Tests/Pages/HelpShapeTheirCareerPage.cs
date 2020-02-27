using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class HelpShapeTheirCareerPage : CampaingnsBasePage
    {
        protected override string PageTitle => "HELP SHAPE THEIR CAREER";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Links => By.CssSelector("a");

        public HelpShapeTheirCareerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void VerifyLinks()
        {
            var internalLinks = pageInteractionHelper.FindElements(Links);

            foreach (var item in internalLinks)
            {
                if (string.IsNullOrEmpty(item.GetAttribute("href")))
                {
                    throw new System.Exception($"{item.Text} link is broken");
                }
            }
        }
    }
}
