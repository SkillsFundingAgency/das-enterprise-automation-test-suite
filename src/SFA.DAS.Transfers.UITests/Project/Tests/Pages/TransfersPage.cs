using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransfersPage : TransfersBasePage
    {
        protected override string PageTitle => "Transfers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConnectToReceivingEmployer => By.LinkText("Connect to a receiving employer");
        private By YourTransferConnectionsRows => By.CssSelector("tbody tr");
        private By DetailsLink => By.LinkText("Details");

        public TransfersPage(ScenarioContext context) : base(context) => _context = context;

        public ConnectWithReceivingEmployerPage ConnectWithReceivingEmployer()
        {
            formCompletionHelper.ClickElement(ConnectToReceivingEmployer);
            return new ConnectWithReceivingEmployerPage(_context);
        }

        public TransferConnectionRequestDetailsPage ViewTransferConnectionRequestDetails(string sender)
        {
            List<IWebElement> transferRequestRows = pageInteractionHelper.FindElements(YourTransferConnectionsRows);
            List<IWebElement> transferRequestDetailsLinks = pageInteractionHelper.FindElements(DetailsLink);
            int i = 0;

            foreach (IWebElement transferRequestRow in transferRequestRows)
            {
                if (transferRequestRow.Text.Contains($"{sender.ToUpper()} Pending"))
                {
                    formCompletionHelper.ClickElement(transferRequestDetailsLinks[i]);
                    return new TransferConnectionRequestDetailsPage(_context);
                }
                i++;
            }
            throw new Exception("Could not find pending transfer request from " + sender);
        }

        public bool CheckTransferConnectionStatus(string Employer)
        {
            if (pageInteractionHelper.IsElementDisplayed(YourTransferConnectionsRows))
            {
                IList<IWebElement> transferRequestRows = pageInteractionHelper.FindElements(YourTransferConnectionsRows);

                foreach (IWebElement transferRequestRow in transferRequestRows)
                {
                    if (transferRequestRow.Text.ToUpper().Contains(Employer.ToUpper())
                        && transferRequestRow.Text.Contains("Approved"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public TransferRequestDetailsPage OpenPendingCohortRequestAsFundingEmployer()
        {
            var receivingEmployer = transfersUser.SecondOrganisationName;
            var cohortTotalCost = objectContext.GetApprenticeTotalCost();

            var transferRequestRows = pageInteractionHelper.FindElements(YourTransferConnectionsRows).Reverse<IWebElement>();
            var transferRequestDetailsLinks = pageInteractionHelper.FindElements(By.PartialLinkText("Details"));

            int i = transferRequestRows.Count() - 1;

            foreach (IWebElement transferRequestRow in transferRequestRows)
            {
                if (transferRequestRow.Text.ToUpper().Contains(receivingEmployer.ToUpper())
                    && transferRequestRow.Text.Contains("Pending")
                    && transferRequestRow.Text.Contains(cohortTotalCost))
                {
                    formCompletionHelper.ClickElement(transferRequestDetailsLinks[i]);
                    return new TransferRequestDetailsPage(_context);
                }
                i--;
            }
            throw new Exception("Unable to find Pending Cohort Request from " + receivingEmployer + " with total cost of the cohort: £" + cohortTotalCost);
        }
    }
}