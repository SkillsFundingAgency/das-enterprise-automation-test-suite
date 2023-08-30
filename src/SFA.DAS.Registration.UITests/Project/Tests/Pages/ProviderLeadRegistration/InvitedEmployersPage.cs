using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class InvitedEmployersPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Manage employer invitations";

        public InvitedEmployersPage(ScenarioContext context) : base(context) { }

        #region Locators
        private By ResendInvitationLink => By.Id($"resendInvitation-{objectContext.GetRegisteredEmail().ToLower()}");
        private By ViewStatusLink => By.Id($"viewStatus-{objectContext.GetRegisteredEmail().ToLower()}");
        private static By TRows => By.CssSelector("tbody tr");
        private static By THeader => By.CssSelector("thead th");
        private static By TData => By.CssSelector("td");
        #endregion

        public void VerifyStatus(string status)
        {
            pageInteractionHelper.VerifyPage(() => GetTableValueByHeader("Employer email", objectContext.GetRegisteredEmail(), "Status"), status);
        }

        private IWebElement GetTableValueByHeader(string rowIdentifierHeaderName, string rowIdentifierValue, string columnValueHeaderName)
        {
            var headers = pageInteractionHelper.FindElements(THeader).ToList();
            var rows = pageInteractionHelper.FindElements(TRows).ToList();
            var rowIdentifierHeaderindex = headers.FindIndex(x => string.Equals(x.Text, rowIdentifierHeaderName, StringComparison.OrdinalIgnoreCase));

            foreach (var row in rows)
            {
                var cells = row.FindElements(TData).ToList();
                if (string.Equals(cells[rowIdentifierHeaderindex].Text, rowIdentifierValue, StringComparison.OrdinalIgnoreCase))
                {
                    var headerNameindex = headers.FindIndex(x => string.Equals(x.Text, columnValueHeaderName, StringComparison.OrdinalIgnoreCase));
                    return cells[headerNameindex];
                }
            }

            throw new NotFoundException($"row with value '{rowIdentifierValue}' in '{rowIdentifierHeaderName}' not found");
        }

        public CheckDetailsPage ResendInvitation()
        {
            formCompletionHelper.Click(ResendInvitationLink);
            return new CheckDetailsPage(context);
        }

        public EmployerAccountStatusPage ViewStatus()
        {
            formCompletionHelper.Click(ViewStatusLink);   
            return new EmployerAccountStatusPage(context);
        }
    }
}