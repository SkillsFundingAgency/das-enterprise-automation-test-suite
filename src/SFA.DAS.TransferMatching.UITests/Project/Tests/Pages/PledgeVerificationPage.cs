using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeVerificationPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Your pledge has been created as pledge";

        protected override By PageHeader => PanelTitle;

        public PledgeVerificationPage SetPledgeDetail()
        {
            var hashedAccountId = GetAccountHashedIdFromUrl();

            var publicHashedAccountId = context.Get<AccountsDbSqlHelper>().GetPublicHashedAccountIdByHashedId(hashedAccountId);

            var pledgeid = RegexHelper.Replace(pageInteractionHelper.GetText(PageHeader), [PageTitle]);

            objectContext.SetPledgeDetail(pledgeid, publicHashedAccountId);

            return this;
        }

        public MyTransferPledgesPage ViewYourPledges()
        {
            formCompletionHelper.ClickLinkByText("View your pledges");

            return new MyTransferPledgesPage(context);
        }

        private string GetAccountHashedIdFromUrl()
        {
            var currentUrl = GetUrl();

            int subStringIndexFrom = currentUrl.IndexOf("/accounts/") + "/accounts/".Length;
            int subStringIndexTo = currentUrl.LastIndexOf("/pledges");

            return currentUrl[subStringIndexFrom..subStringIndexTo];
        }
    }
}