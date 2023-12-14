using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class Pledge100PercentMatchPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Approve or delay applications for 100% match";

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public CreateATransferPledgePage EnterValidMatchChoice(bool immediateMatch)
        {
            SelectMatchChoice(immediateMatch);

            return new CreateATransferPledgePage(context);
        }

        private void SelectMatchChoice(bool immediateMatch)
        {
            string radioOption = immediateMatch ? "Approve immediately, no delay" : "I want to do my own checks; I understand I have up to 6 weeks to complete them";

            formCompletionHelper.SelectRadioOptionByText(radioOption);

            Continue();
        }

    }
}