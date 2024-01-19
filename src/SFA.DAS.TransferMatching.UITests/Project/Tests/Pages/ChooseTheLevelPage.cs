using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ChooseTheLevelPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Choose the levels of apprenticeship training you'd like to fund";

        protected override By ContinueButton => By.CssSelector("#pledge-level-continue");

        public CreateATransferPledgePage SelectLevelAndContinue() => SelectAndContinue();
    }
}