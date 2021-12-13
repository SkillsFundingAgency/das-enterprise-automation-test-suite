using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeVerificationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Your pledge has been created as pledge";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        public PledgeVerificationPage(ScenarioContext context) : base(context) { }

        public PledgeVerificationPage SetPledgeDetail()
        {
            var pledgeid = RegexHelper.Replace(pageInteractionHelper.GetText(PageHeader), new List<string>() { PageTitle });

            objectContext.SetPledgeDetail(pledgeid);

            return this;
        }

        public MyTransferPledgesPage ViewYourPledges()
        {
            formCompletionHelper.ClickLinkByText("View your pledges");

            return new MyTransferPledgesPage(_context);
        }
    }
}