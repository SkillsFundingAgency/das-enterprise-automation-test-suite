using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class OrgPage(ScenarioContext context, bool navigate) : UserOrgBasePage(context, navigate)
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='tabs-nav-item-organizations']");

        protected override string PageTitle => dataHelper.NewOrgName;

        protected override PageTypeEnum PageType => PageTypeEnum.Org;

        public HomePage VerifyDetails()
        {
            VerifyUserDetails("Organisation Type", dataHelper.Type);
            VerifyUserDetails("Organisation Status", dataHelper.Status);
            return VerifyUserDetails("Account Manager Status", dataHelper.AccountManagerStatus);
        }

        public OrgPage EnterDetails()
        {
            SelectOptions("Organisation Type", dataHelper.Type);
            SelectOptions("Organisation Status", dataHelper.Status);
            SelectOptions("Account Manager Status", dataHelper.AccountManagerStatus);

            EnterText("Address Line 1", dataHelper.AddressLine1);
            EnterText("Address Line 2", dataHelper.AddressLine2);
            EnterText("Address Line 3", dataHelper.AddressLine3);
            EnterText("City", dataHelper.City);
            EnterText("County", dataHelper.County);
            EnterText("Postcode", dataHelper.Postcode);
            EnterText("Account Manager Name", dataHelper.NewUserFullName);
            EnterText("Account Manager E-mail", dataHelper.NewUserEmail);

            return this;
        }
    }
}
