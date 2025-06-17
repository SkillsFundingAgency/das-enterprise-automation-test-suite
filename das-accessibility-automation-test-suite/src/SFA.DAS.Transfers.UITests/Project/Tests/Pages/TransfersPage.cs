using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Registration.UITests.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransfersPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Transfers";

        protected override bool TakeFullScreenShot => false;

        private static By ConnectToReceivingEmployer => By.LinkText("Connect to a receiving employer");
        private static By ConnectionsSendRows => By.CssSelector("#connections-send tbody tr");
        private static By ConnectionsReceiveRows => By.CssSelector("#connections-receive tbody tr");
        private static By TransfersSendRows => By.CssSelector("#transfers-send tbody tr");
        private static By DetailsLink => By.PartialLinkText("Details");

        public ConnectWithReceivingEmployerPage ConnectWithReceivingEmployer()
        {
            formCompletionHelper.ClickElement(ConnectToReceivingEmployer);
            return new ConnectWithReceivingEmployerPage(context);
        }

        public TransferConnectionRequestDetailsPage ViewTransferConnectionRequestDetails(string sender)
        {
            List<IWebElement> transferRequestRows = pageInteractionHelper.FindElements(ConnectionsReceiveRows);
            foreach (IWebElement transferRequestRow in transferRequestRows)
            {
                if (transferRequestRow.Text.Contains($"{sender.ToUpper()}", StringComparison.CurrentCultureIgnoreCase)
                    && transferRequestRow.Text.Contains("Pending"))
                {
                    var detailsLiink = transferRequestRow.FindElements(DetailsLink).FirstOrDefault();
                    if (detailsLiink != null)
                    {
                        formCompletionHelper.ClickElement(detailsLiink);
                        return new TransferConnectionRequestDetailsPage(context);
                    }
                }
            }

            throw new Exception("Could not find pending transfer request from " + sender);
        }

        public bool CheckTransferConnectionStatus(string Employer, string role)
        {
            By by;
            switch (role)
            {
                case "send":
                    by = ConnectionsSendRows;
                    break;
                case "receive":
                    by = ConnectionsReceiveRows;
                    break;
                default:
                    return false;
            }

            if (pageInteractionHelper.IsElementDisplayed(by))
            {
                IList<IWebElement> rows = pageInteractionHelper.FindElements(by);

                foreach (IWebElement row in rows)
                {
                    if (row.Text.Contains(Employer, StringComparison.CurrentCultureIgnoreCase)
                        && row.Text.Contains("Approved"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public TransferRequestDetailsPage OpenPendingCohortRequestAsFundingEmployer()
        {
            var receivingEmployer = objectContext.GetTransferReceiverOrganisationName();
            var cohortTotalCost = objectContext.GetApprenticeTotalCost();

            // the new transfer is likely to be at the bottom and as the cost is random starting at the bottom should
            // find the transfer which has funded the current apprentice
            var transfersSendRows = pageInteractionHelper.FindElements(TransfersSendRows).Reverse<IWebElement>();
            foreach (IWebElement transfersSendRow in transfersSendRows)
            {
                if (transfersSendRow.Text.Contains(receivingEmployer, StringComparison.CurrentCultureIgnoreCase)
                    && transfersSendRow.Text.Contains("Pending")
                    && transfersSendRow.Text.Contains(cohortTotalCost))
                {
                    var detailsLiink = transfersSendRow.FindElements(DetailsLink).FirstOrDefault();
                    if (detailsLiink != null)
                    {
                        formCompletionHelper.ClickElement(detailsLiink);
                        return new TransferRequestDetailsPage(context);
                    }
                }
            }

            throw new Exception($"Unable to find Pending Cohort Request from {receivingEmployer} with total cost of the cohort: {cohortTotalCost}");
        }
    }
}