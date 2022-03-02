using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticeDetailsSavedSuccessfully : ApprovalsBasePage
    {
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected override string PageTitle => "New apprentice details saved successfully";
        private By cohortsSaveTable => By.CssSelector(".govuk-table__body");
        private By cohortsSaveTableRows => By.CssSelector("tbody tr");

        public ProviderNewApprenticeDetailsSavedSuccessfully(ScenarioContext _context) : base(_context)
        {
            _pageInteractionHelper = _context.Get<PageInteractionHelper>();
            VerifyPage();

        }

        public void GetTable()
        {
            //var x = pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(rowIdentifier, Status));
            var table = _pageInteractionHelper.FindElements(cohortsSaveTable).Where(x => x.Enabled && x.Displayed).ElementAtOrDefault(0);
            var tableRows = table.FindElements(cohortsSaveTableRows);


        }

    }
}
