using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "My transfer pledges";

        private static By CreatePledgesSelector => By.CssSelector("[href*='/pledges/create/inform']");
        private By PledgeSelector => By.CssSelector($"a[href='pledges/{GetPledgeId()}/applications']");
        private static By NextPageLink => By.XPath("//a[contains(text(),'Next')]");
        private static By StatusColumn => By.ClassName("govuk-tag");

        public TransferPledgePage GoToTransferPledgePage()
        {
            SearchPledge();
            formCompletionHelper.Click(PledgeSelector);
            return new TransferPledgePage(context);
        }

        public PledgeAndTransferYourLevyFundsPage CreatePledge()
        {
            formCompletionHelper.Click(CreatePledgesSelector);
            return new PledgeAndTransferYourLevyFundsPage(context);
        }

        public MyTransferPledgesPage ConfirmStatus(string expectedStatus)
        {
            SearchPledge();
            var actualStatus = tableRowHelper.GetColumn(GetPledgeId(), StatusColumn).Text;
            Assert.That(actualStatus, Is.EqualTo(expectedStatus));
            return new MyTransferPledgesPage(context);
        }

        private void SearchPledge()
        {
            while (pageInteractionHelper.IsElementDisplayed(NextPageLink))
            {
                if (pageInteractionHelper.IsElementDisplayed(PledgeSelector))
                    break;
                else
                    formCompletionHelper.ClickElement(NextPageLink);

                pageInteractionHelper.WaitForElementToBeDisplayed(NextPageLink);
            }

            VerifyElement(PledgeSelector);
        }


    }
}