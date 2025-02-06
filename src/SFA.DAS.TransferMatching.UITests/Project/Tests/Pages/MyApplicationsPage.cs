using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
   
    public class MyApplicationsPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "My applications";
        private By PledgeSelector => By.XPath($"//a[contains(text(),'{GetPledgeId()}')]");
        private static By NextPageLink => By.XPath("//a[contains(text(),'Next')]");

        public ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus)
        {
            SearchPledge();
            formCompletionHelper.ClickLinkByText(GetPledgeId());
            return new ApplicationsDetailsPage(context, expectedStatus);
        }
        private void SearchPledge()
        {
            // Continue until either PledgeSelector is found or no more pages to go through
            while (pageInteractionHelper.IsElementDisplayed(NextPageLink))
            {
                if (pageInteractionHelper.IsElementDisplayed(PledgeSelector))
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

            VerifyElement(PledgeSelector);
        }

    }
}

