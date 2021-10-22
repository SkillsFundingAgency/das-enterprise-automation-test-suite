using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferFundDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => string.Empty;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By DasHighlight => By.CssSelector(".das-highlight");

        protected override By ContinueButton => By.CssSelector("#apply-application-continue");

        public TransferFundDetailsPage(ScenarioContext context, bool isAnonymousPledge = false) : base(context)
        {
            _context = context;

            var pledgeid = objectContext.GetPledgeDetail().PledgeId;

            if (isAnonymousPledge)
            {
                VerifyPage(PageHeader, $"Transfer fund details for opportunity ({pledgeid})");
                VerifyPage(DasHighlight, $"A levy-paying business wants to fund apprenticeship training");
            }
            else
            {
                var orgName = objectContext.GetOrganisationName();
                VerifyPage(PageHeader, $"Transfer fund details for {orgName} ({pledgeid})");
                VerifyPage(DasHighlight, $"{orgName} ({pledgeid}) wants to fund apprenticeship training");
            }
        }

        public SignInPage ApplyForTransferFunds()
        {
            SelectRadioOptionByText("Yes, apply for transfer funds");

            Continue();

            return new SignInPage(_context);
        }
    }
}