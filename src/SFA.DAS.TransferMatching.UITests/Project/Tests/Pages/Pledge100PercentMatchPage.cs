using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class Pledge100PercentMatchPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Do you want to approve 100% matches immediately?";

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public CreateATransferPledgePage EnterValidMatchChoice(bool immediateMatch)
        {
            SelectMatchChoice(immediateMatch);

            return new CreateATransferPledgePage(context);
        }

        private void SelectMatchChoice(bool immediateMatch)
        {
            string radioOption = immediateMatch ? "Yes, automatically approve 100% matches immediately" : "No, I would like 6 weeks to approve or reject 100% matches. If I do not take any action in 6 weeks, they will be approved automatically";

            formCompletionHelper.SelectRadioOptionByText(radioOption);

            Continue();
        }

    }
}