using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class FilteredManageYourApprenticesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override bool TakeFullScreenShot => false;

        private static By Status => By.CssSelector("td.govuk-table__cell[data-label='Status']");

        public string GetStatus(string rowIdentifier) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(rowIdentifier, Status));

    }
}

