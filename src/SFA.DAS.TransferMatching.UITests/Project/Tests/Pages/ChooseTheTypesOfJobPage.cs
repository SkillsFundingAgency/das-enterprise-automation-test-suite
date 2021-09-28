using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ChooseTheTypesOfJobPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Choose the types of job role you'd like to fund";

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public ChooseTheTypesOfJobPage(ScenarioContext context) : base(context) { }

        public CreateATransferPledgePage SelectTypeOfJobAndContinue() => SelectAndContinue();
    }
}