using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AddtheLocationPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Add the locations you'd like to fund";

        protected static By Location => By.CssSelector("#Locations_0_");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public CreateATransferPledgePage EnterLocation()
        {
            formCompletionHelper.EnterText(Location, Helpers.TMDataHelper.GetRandomLocation());

            formCompletionHelper.ClickElement(PageHeader);

            Continue();

            return new CreateATransferPledgePage(context);
        }
    }
}