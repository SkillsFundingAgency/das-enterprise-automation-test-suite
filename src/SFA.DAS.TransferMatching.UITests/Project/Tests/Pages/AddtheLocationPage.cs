using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AddtheLocationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Add the locations you'd like to fund";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By Location => By.CssSelector("#Locations_0_");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public AddtheLocationPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransferPledgePage EnterLocation()
        {
            formCompletionHelper.EnterText(Location, tMDataHelper.GetRandomLocation());

            formCompletionHelper.ClickElement(PageHeader);

            Continue();

            return new CreateATransferPledgePage(_context);
        }
    }
}