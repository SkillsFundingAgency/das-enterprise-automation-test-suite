using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeVerificationPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Your pledge has been created as pledge";

        protected override By PageHeader => PanelTitle;

        public PledgeVerificationPage SetPledgeDetail()
        {
            var pledgeid = RegexHelper.Replace(pageInteractionHelper.GetText(PageHeader), [PageTitle]);

            objectContext.SetPledgeDetail(pledgeid);

            return this;
        }

        public MyTransferPledgesPage ViewYourPledges()
        {
            formCompletionHelper.ClickLinkByText("View your pledges");

            return new MyTransferPledgesPage(context);
        }
    }
}