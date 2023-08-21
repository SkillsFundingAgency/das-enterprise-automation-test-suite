using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ManageTransferMatchingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Manage transfers";

        private static By CreateTransferPledgeSelector => By.LinkText("Create a transfers pledge");
        private static By ApplyForTransferOppurtunitySelector => By.LinkText("Apply for transfer opportunities");
        private static By TransferAllowanceSection => By.TagName("column-two-thirds");

        public ManageTransferMatchingPage(ScenarioContext context) : base(context) { }

        public ManageTransferMatchingPage VerifyTransferAllowanceText()
        {
            pageInteractionHelper.IsElementDisplayed(TransferAllowanceSection);
            return this;
        }

        public AccountHomePage GoToAccountHomePage()
        {
            formCompletionHelper.ClickLinkByText("Home");
            return new AccountHomePage(context);
        }

        public PledgeAndTransferYourLevyFundsPage GotoCreateTransfersPledgePage()
        {
            formCompletionHelper.Click(CreateTransferPledgeSelector);
            return new PledgeAndTransferYourLevyFundsPage(context);
        }

        public MyTransferPledgesPage GoToViewMyTransferPledgePage()
        {
            formCompletionHelper.ClickLinkByText("View my transfer pledges and applications");
            return new MyTransferPledgesPage(context);
        }

        public FindABusinessPage GoToFindABusinessPage()
        {
            formCompletionHelper.Click(ApplyForTransferOppurtunitySelector);
            return new FindABusinessPage(context);
        }

        public MyApplicationsPage ViewApplicationsIhaveSubmitted()
        {
            formCompletionHelper.ClickLinkByText("View applications I've submitted");
            return new MyApplicationsPage(context);
        }

        public bool CanCreateTransferPledge() => pageInteractionHelper.IsElementDisplayed(CreateTransferPledgeSelector);

        public bool CanApplyForTransferOppurtunity() => pageInteractionHelper.IsElementDisplayed(ApplyForTransferOppurtunitySelector);
    }
}