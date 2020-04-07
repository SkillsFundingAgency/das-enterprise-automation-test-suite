using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class InvitedEmployersPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Invited employers";

        public InvitedEmployersPage(ScenarioContext context) : base(context) { VerifyPage(); }

        private By TRows => By.CssSelector("tbody tr");
        private By THeader => By.CssSelector("thead th");
        private By TData => By.CssSelector("td");

        public void VerifyStatus(string status) => pageInteractionHelper.VerifyPage(() => GetTableData("Employer email", objectContext.GetRegisteredEmail(), "Status"), status);

        private IWebElement GetTableData(string rowIdentifierHeadername, string rowIdentifierHeaderValue, string headerName)
        {
            var headers = pageInteractionHelper.FindElements(THeader).ToList();

            var rowIdentifierHeaderindex = headers.FindIndex(x => x.Text.ContainsCompareCaseInsensitive(rowIdentifierHeadername));

            var headerNameindex = headers.FindIndex(x => x.Text.ContainsCompareCaseInsensitive(headerName));

            var rows = pageInteractionHelper.FindElements(TRows).ToList();

            foreach (var row in rows)
            {
                var tDatas = row.FindElements(TData).ToList();
                if (tDatas[rowIdentifierHeaderindex].Text == rowIdentifierHeaderValue)
                {
                    return tDatas[headerNameindex];
                }
            }

            throw new NotFoundException($"row with value '{rowIdentifierHeaderValue}' against header '{rowIdentifierHeadername}' not found");
        }
    }
}