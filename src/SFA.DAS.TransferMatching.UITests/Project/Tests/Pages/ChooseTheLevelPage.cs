using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ChooseTheLevelPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Choose the levels of apprenticeship training you'd like to fund";

        protected override By ContinueButton => By.CssSelector("#pledge-level-continue");

        public ChooseTheLevelPage(ScenarioContext context) : base(context) { }

        public CreateATransferPledgePage SelectLevelAndContinue() => SelectAndContinue();
    }
}