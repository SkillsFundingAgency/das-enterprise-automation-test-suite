using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApplicationsDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"({GetPledgeId()}) application details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#fund-transfer-accept");

        private By InformationSelector => By.CssSelector("#TruthfulInformation");

        private By ComplyWithRulesSelector = By.CssSelector("#ComplyWithRules");

        private By ErrorTitle => By.CssSelector("#main-content .govuk-error-summary");

        public ApplicationsDetailsPage(ScenarioContext context, string applicationStatus) : base(context, false)
        {
            _context = context;

            VerifyApplicationStatus(applicationStatus);

            if (applicationStatus == "FUNDS AVAILABLE") VerifyPage(PageHeader, $"{GetPledgeId()}");
            else VerifyPage();
        }

        public ApplicationsDetailsPage SetPledgeApplication() 
        {
            var applicationid = GetUrl().Split("/").ToList().LastOrDefault();

            objectContext.SetPledgeApplication(GetPledgeId(), applicationid);

            return this;
        }

        public AcceptedTransferPage VerifyAgreeToTermsIsMandatoryAndAcceptFunding()
        {
            SelectRadioOptionByText("Yes, accept the funding");

            Continue();

            VerifyPage(ErrorTitle, "You must agree to the terms and conditions before accepting funding for this application");

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(InformationSelector));

            Continue();

            VerifyPage(ErrorTitle, "You must agree to the terms and conditions before accepting funding for this application");
            
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(InformationSelector));

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ComplyWithRulesSelector));

            Continue();

            VerifyPage(ErrorTitle, "You must agree to the terms and conditions before accepting funding for this application");
            
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(InformationSelector));

            Continue();

            return new AcceptedTransferPage(_context);
        }
    }
}