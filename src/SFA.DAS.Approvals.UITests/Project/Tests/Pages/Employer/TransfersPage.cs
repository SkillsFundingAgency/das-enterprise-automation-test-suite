using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransfersPage : BasePage
    {
        protected override string PageTitle => "Transfers";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly TransfersConfig _transfersConfig;
        private readonly ObjectContext _objectContext;
        #endregion

        private By ConnectToReceivingEmployer => By.LinkText("Connect to a receiving employer");
        private By YourTransferConnectionsRows => By.CssSelector("tbody tr");
        private By DetailsLink => By.LinkText("Details");

        public TransfersPage(ScenarioContext context): base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _transfersConfig = context.GetTransfersConfig<TransfersConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }


        public ConnectWithReceivingEmployerPage ConnectWithReceivingEmployer()
        {
            _formCompletionHelper.ClickElement(ConnectToReceivingEmployer);
                return new ConnectWithReceivingEmployerPage(_context);
        }

        public TransferConnectionRequestDetailsPage ViewTransferConnectionRequestDetails(string sender)
        {
            List<IWebElement> transferRequestRows = _pageInteractionHelper.FindElements(YourTransferConnectionsRows);
            List<IWebElement> transferRequestDetailsLinks = _pageInteractionHelper.FindElements(DetailsLink);
            int i = 0;

            foreach (IWebElement transferRequestRow in transferRequestRows)
            {
                if ((transferRequestRow.Text.Contains($"{sender.ToUpper()} Pending")))
                {
                    _formCompletionHelper.ClickElement(transferRequestDetailsLinks[i]);
                    return new TransferConnectionRequestDetailsPage(_context);
                }
                i++;
            }
            throw new Exception("Could not find pending transfer request from " + sender);
        }

        public bool CheckTransferConnectionStatus(String Employer)
        {
            if (_pageInteractionHelper.IsElementDisplayed(YourTransferConnectionsRows))
            {
                IList<IWebElement> transferRequestRows = _pageInteractionHelper.FindElements(YourTransferConnectionsRows);

                foreach (IWebElement transferRequestRow in transferRequestRows)
                {
                    if ((transferRequestRow.Text.ToUpper().Contains(Employer.ToUpper()))
                        && (transferRequestRow.Text.Contains("Approved")))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal TransferRequestDetailsPage OpenPendingCohortRequestAsFundingEmployer()
        {
            var receivingEmployer = _transfersConfig.AP_ReceiverOrganisationName;
            var cohortTotalCost = _objectContext.GetApprenticeTotalCost();

            IList<IWebElement> transferRequestRows = _pageInteractionHelper.FindElements(YourTransferConnectionsRows);
            IList<IWebElement> transferRequestDetailsLinks = _pageInteractionHelper.FindElements(DetailsLink);
            int i = 0;

            foreach (IWebElement transferRequestRow in transferRequestRows)
            {
                if ((transferRequestRow.Text.ToUpper().Contains(receivingEmployer.ToUpper()))
                    && ((transferRequestRow.Text.Contains("Pending"))
                    && (transferRequestRow.Text.Contains(cohortTotalCost))))
                {
                    _formCompletionHelper.ClickElement(transferRequestDetailsLinks[i]);
                    return new TransferRequestDetailsPage(_context);
                }
                i++;
            }
            throw new Exception("Unable to find Pending Cohort Request from " + receivingEmployer + " with total cost of the cohort: £" + cohortTotalCost);
        }
    }
}