using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferPledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"Transfer pledge {GetPledgeId()}";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By PledgeApplicationSelector => By.CssSelector($"[href='applications/{objectContext.GetPledgeApplication(GetPledgeId())}]");

        public TransferPledgePage(ScenarioContext context) : base(context) => _context = context;

        public ApproveAppliationPage GoToApproveAppliationPage()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetOrganisationName());
            return new ApproveAppliationPage(_context);
        }
    }
}