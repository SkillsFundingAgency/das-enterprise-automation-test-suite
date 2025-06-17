using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ChoosetheSectorsPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Choose the sectors you'd like to fund";

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public CreateATransferPledgePage SelectSetorAndContinue() => SelectAndContinue();
    }
}