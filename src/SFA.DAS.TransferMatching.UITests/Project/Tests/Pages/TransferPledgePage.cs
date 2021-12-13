using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferPledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"Transfer pledge {GetPledgeId()}";

        private By PledgeApplicationSelector => By.CssSelector($"[href='applications/{objectContext.GetPledgeApplication(GetPledgeId())}]");

        public TransferPledgePage(ScenarioContext context) : base(context) { }

        public ApproveAppliationPage GoToApproveAppliationPage()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetOrganisationName());
            return new ApproveAppliationPage(_context);
        }
    }
}