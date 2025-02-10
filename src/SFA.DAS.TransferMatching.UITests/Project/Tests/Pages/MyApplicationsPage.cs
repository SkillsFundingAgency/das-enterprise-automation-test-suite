using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyApplicationsPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "My applications";
        private static By NextPageLink => By.XPath("//a[contains(text(),'Next')]");
        private By ApplicationSelector => By.CssSelector($"a[href='applications/{GetPledgeId()}']");


        public ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus)
        {
            SearchForApplication();
            formCompletionHelper.ClickLinkByText(GetPledgeId());
            return new ApplicationsDetailsPage(context, expectedStatus);
        }

        private void SearchForApplication()
        {
            // Continue until either ApplicationSelector is found or no more pages to go through
            do
            {
                if (pageInteractionHelper.IsElementDisplayed(ApplicationSelector))
                    break;

                if (pageInteractionHelper.IsElementDisplayed(NextPageLink))
                {
                    formCompletionHelper.ClickElement(NextPageLink);
                }
                else
                {
                    break;
                }
            }
            while (true);
        }
    }
}