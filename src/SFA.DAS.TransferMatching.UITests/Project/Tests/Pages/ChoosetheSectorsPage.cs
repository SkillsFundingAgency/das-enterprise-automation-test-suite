using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ChoosetheSectorsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Choose the sectors you'd like to fund";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public ChoosetheSectorsPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransferPledgePage SelectSetorAndContinue() => SelectAndContinue();
    }
}