using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class EmployerAccountStatusPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Employer account status";

        #region locators
        private static By TRows => By.CssSelector(".govuk-summary-list__row");
        private static By THeader => By.CssSelector(".govuk-summary-list__key");
        private static By TData => By.CssSelector(".govuk-summary-list__value");
        #endregion

        public EmployerAccountStatusPage(ScenarioContext context) : base(context) { }

        public EmployerAccountStatusPage VerifyStatus(string status, string value)
        {
            pageInteractionHelper.VerifyPage(() => GetData(status), value);
            return this;
        }

        protected IWebElement GetData(string headerName)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text == headerName)
                {
                    return row.FindElement(TData);
                }
            }
            
            throw new NotFoundException($"{headerName} not found");
        }

        public new InvitedEmployersPage ClickBackLink()
        {
            NavigateBack();
            return new InvitedEmployersPage(context);
        }
    }
}