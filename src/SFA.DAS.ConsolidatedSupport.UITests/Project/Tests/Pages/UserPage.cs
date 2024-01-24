using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class UserPage(ScenarioContext context) : UserOrgBasePage(context, true)
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='tabs-nav-item-users']");

        protected override string PageTitle => ConsolidateSupportDataHelper.NewUserFullName;

        private static By AllRecordsFields => By.CssSelector(".property_box > .ember-view .property");

        private static By OrganisationTab => By.CssSelector("[data-test-id='tabs-nav-item-organizations']");

        private static By OrganisationName => By.CssSelector("[data-test-id='organization-add-modal-name-input']");

        private static By OrganisationDomain => By.CssSelector("[data-test-id='organization-add-modal-domain-input']");

        private static By AddOrganisationButton => By.CssSelector("[data-test-id='organization-add-modal-submit-button']");

        protected override PageTypeEnum PageType => PageTypeEnum.User;

        public void CreateOrganisation()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(OrganisationTab), false);

            formCompletionHelper.EnterText(OrganisationName, dataHelper.NewOrgName);

            formCompletionHelper.EnterText(OrganisationDomain, ConsolidateSupportDataHelper.NewOrgDomain);

            formCompletionHelper.ClickElement(AddOrganisationButton);
        }

        public void VerifyOrganisationDetails()
        {
            NavigateToOrganisation();

            pageInteractionHelper.InvokeAction(() => formCompletionHelper.ClickElement(OrganisationTab));

            VerifyElement(OrganisationTab, dataHelper.NewOrgName);

            VerifyElement(() => pageInteractionHelper.FindElements(AllRecordsFields), ConsolidateSupportDataHelper.NewOrgDomain.ToLower());
        }

        public HomePage VerifyDetails() => VerifyUserDetails("Contact Type", ConsolidateSupportDataHelper.Type);

        public UserPage EnterDetails()
        {
            SelectOptions("Contact Type", ConsolidateSupportDataHelper.Type);
            EnterText("Address Line 1", ConsolidateSupportDataHelper.AddressLine1);
            EnterText("Address Line 2", ConsolidateSupportDataHelper.AddressLine2);
            EnterText("Address Line 3", ConsolidateSupportDataHelper.AddressLine3);
            EnterText("City", ConsolidateSupportDataHelper.City);
            EnterText("Postcode", ConsolidateSupportDataHelper.Postcode);

            return this;
        }
    }
}
