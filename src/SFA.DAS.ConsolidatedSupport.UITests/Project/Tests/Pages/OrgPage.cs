using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
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
            VerifyUserDetails("Organisation Type", ConsolidateSupportDataHelper.Type);
            VerifyUserDetails("Organisation Status", ConsolidateSupportDataHelper.Status);
            return VerifyUserDetails("Account Manager Status", ConsolidateSupportDataHelper.AccountManagerStatus);
        }

        public OrgPage EnterDetails()
        {
            SelectOptions("Organisation Type", ConsolidateSupportDataHelper.Type);
            SelectOptions("Organisation Status", ConsolidateSupportDataHelper.Status);
            SelectOptions("Account Manager Status", ConsolidateSupportDataHelper.AccountManagerStatus);

            EnterText("Address Line 1", ConsolidateSupportDataHelper.AddressLine1);
            EnterText("Address Line 2", ConsolidateSupportDataHelper.AddressLine2);
            EnterText("Address Line 3", ConsolidateSupportDataHelper.AddressLine3);
            EnterText("City", ConsolidateSupportDataHelper.City);
            EnterText("County", ConsolidateSupportDataHelper.County);
            EnterText("Postcode", ConsolidateSupportDataHelper.Postcode);
            EnterText("Account Manager Name", ConsolidateSupportDataHelper.NewUserFullName);
            EnterText("Account Manager E-mail", ConsolidateSupportDataHelper.NewUserEmail);

            return this;
        }
    }
}
