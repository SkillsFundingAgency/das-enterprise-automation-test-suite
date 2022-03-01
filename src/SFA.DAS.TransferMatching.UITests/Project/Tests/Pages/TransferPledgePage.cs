using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferPledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"Transfer pledge {GetPledgeId()}";

        private By PledgeApplicationSelector => By.CssSelector($"[href='applications/{objectContext.GetPledgeApplication(GetPledgeId())}]");

        private By DownloadSelector => By.CssSelector("#main-content > div > div:nth-child(1) > div.govuk-grid-column-one-third > p > a");

        private By ClosePLedgeSelector => By.CssSelector("#main-content > div > div:nth-child(2) > div > div > form:nth-child(2) > button");
        public TransferPledgePage(ScenarioContext context) : base(context) { }

        public ClosePledgePage ClosePledge()
        {
            formCompletionHelper.Click(ClosePLedgeSelector);
            return new ClosePledgePage(context);
        }

        public TransferPledgePage DownloadExcel()
        {
            formCompletionHelper.Click(DownloadSelector);
            return new TransferPledgePage(context);
        }

        public ApproveAppliationPage GoToApproveAppliationPage()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetOrganisationName());
            return new ApproveAppliationPage(context);
        }

        public TransferPledgePage SortByApplicant()
        {
            formCompletionHelper.ClickLinkByText("Applicant");
            formCompletionHelper.ClickLinkByText("Estimated cost 2021/22");
            formCompletionHelper.ClickLinkByText("Typical duration");
            formCompletionHelper.ClickLinkByText("Criteria");
            formCompletionHelper.ClickLinkByText("Status");
            return new TransferPledgePage(context);
        }
    }
}