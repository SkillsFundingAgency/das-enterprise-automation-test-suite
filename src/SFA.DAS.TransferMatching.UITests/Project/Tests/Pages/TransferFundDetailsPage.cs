using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferFundDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => string.Empty;

        protected override string AccessibilityPageTitle => "Transfer fund details Page";

        private static By DasHighlight => By.CssSelector(".das-highlight");

        protected override By ContinueButton => By.CssSelector("#apply-application-continue");

        public TransferFundDetailsPage(ScenarioContext context) : base(context) => VerifyPage(PageHeader, $"Transfer fund details for");

        public TransferFundDetailsPage(ScenarioContext context, bool isAnonymousPledge) : base(context)
        {
            var pledgeid = GetPledgeId();

            if (isAnonymousPledge)
            {
                MultipleVerifyPage(new System.Collections.Generic.List<System.Func<bool>> 
                {
                    () => VerifyPage(PageHeader, $"Transfer fund details for opportunity ({pledgeid})"),
                    () => VerifyPage(DasHighlight, $"A levy-paying business wants to fund apprenticeship training")
                });
            }
            else
            {
                var orgName = objectContext.GetOrganisationName();

                MultipleVerifyPage(new System.Collections.Generic.List<System.Func<bool>>
                {
                    () => VerifyPage(PageHeader, $"Transfer fund details for {orgName} ({pledgeid})"),
                    () => VerifyPage(DasHighlight, $"{orgName} ({pledgeid}) wants to fund apprenticeship training")
                });
            }
        }

        public StubSignInEmployerPage ApplyForTransferFunds()
        {
            SelectYesAndContinue();

            return new StubSignInEmployerPage(context);
        }

        public CreateATransfersApplicationPage ApplyForTransferFundsAfterLogin()
        {
            SelectYesAndContinue();

            return new CreateATransfersApplicationPage(context);
        }

        private void SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes, apply for transfer funds");

            Continue();
        }
    }
}