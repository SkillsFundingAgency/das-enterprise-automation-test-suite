using OpenQA.Selenium;
using SFA.DAS.RoatpAdmin.Service.Project;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.AllowList;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class AllowListPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "UKPRN allow list";

        private static By StartDate => By.Id("StartDate");
        private static By EndDate => By.Id("EndDate");
        private static By UkprnField => By.Id("Ukprn");

        private static By ErrorText => By.CssSelector(".govuk-list.govuk-error-summary__list");

        public AllowListPage(ScenarioContext context) : base(context) => VerifyPage();

        private void AddToAllowList()
        {
            formCompletionHelper.EnterText(UkprnField, (objectContext.GetUkprn()));
            formCompletionHelper.SendKeys(StartDate, DateTime.Now.ToString("dd-MMM-yyyy"));
            formCompletionHelper.SendKeys(EndDate, DateTime.Now.AddMonths(+1).ToString("dd-MMM-yyyy"));
            Continue();
        }
        public AllowListPage AddUkprnToAllowList()
        {
            AddToAllowList();
            return this;
        }

        public AllowListPage VerifyDuplicateUkrpnNotAdded()
        {
            AddToAllowList();
            pageInteractionHelper.VerifyText(ErrorText, "UKPRN 10001234 exists in the allow list");
            return this;
        }
        public RemovePage RemoveUkprnFromAllowlist()
        {
            tableRowHelper.SelectRowFromTable("Remove", objectContext.GetUkprn());
            return new RemovePage(context);

        }
    }
}
