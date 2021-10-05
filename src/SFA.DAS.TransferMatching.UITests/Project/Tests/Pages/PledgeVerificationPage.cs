using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeVerificationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Your pledge has been created as pledge";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PledgeVerificationPage(ScenarioContext context) : base(context) => _context = context;

        public PledgeVerificationPage SetPledgeId()
        {
            var pledgeid = regexHelper.Replace(pageInteractionHelper.GetText(PageHeader), new List<string>() { PageTitle });

            objectContext.SetPledgeId(pledgeid);

            return this;
        }

        public MyTransferPledgesPage ViewYourPledges()
        {
            formCompletionHelper.ClickLinkByText("View your pledges");

            return new MyTransferPledgesPage(_context);
        }
    }
}