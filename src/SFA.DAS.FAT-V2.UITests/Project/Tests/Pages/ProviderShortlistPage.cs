using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Collections.Generic;


namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderShortlistPage : FATV2BasePage
    {
        protected override string PageTitle => "Shortlisted training providers";
        private readonly ScenarioContext _context;

        #region
        private By RemoveShortlist => By.CssSelector("button[id^='remove-shortlistitem-']");
        #endregion

        public ProviderShortlistPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderShortlistPage RemoveShortlistedProvider()
        {
            formCompletionHelper.Click(RemoveShortlist);
            return new ProviderShortlistPage(_context);
        }

    }
}
