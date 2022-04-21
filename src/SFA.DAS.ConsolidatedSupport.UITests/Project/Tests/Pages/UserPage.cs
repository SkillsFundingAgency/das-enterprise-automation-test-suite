using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class UserPage : UserOrgBasePage
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='tabs-nav-item-users']");

        protected override string PageTitle => dataHelper.NewUserFullName;

        private By AllRecordsFields => By.CssSelector(".property_box > .ember-view .property");

        private By OrganisationTab => By.CssSelector("[data-test-id='tabs-nav-item-organizations']");

        private By OrganisationName => By.CssSelector("[data-test-id='organization-add-modal-name-input']");

        private By OrganisationDomain => By.CssSelector("[data-test-id='organization-add-modal-domain-input']");

        private By AddOrganisationButton => By.CssSelector("[data-test-id='organization-add-modal-submit-button']");

        protected override PageTypeEnum PageType => PageTypeEnum.User;

        public UserPage(ScenarioContext context) : base(context, true) { }
        
        public void CreateOrganisation()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(OrganisationTab), false);

            formCompletionHelper.EnterText(OrganisationName, dataHelper.NewOrgName);

            formCompletionHelper.EnterText(OrganisationDomain, dataHelper.NewOrgDomain);

            formCompletionHelper.ClickElement(AddOrganisationButton);
        }

        public void VerifyOrganisationDetails()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    VerifyElement(OrganisationTab, dataHelper.NewOrgName, NavigateToOrganisation);
                    break;
                }
                catch (System.Exception)
                {
                    Thread.Sleep(5000);
                }
            }

            VerifyElement(() => pageInteractionHelper.FindElements(AllRecordsFields), dataHelper.NewOrgDomain.ToLower());
        }

        public HomePage VerifyDetails() => VerifyUserDetails("Contact Type", dataHelper.Type);

        public UserPage EnterDetails()
        {
            SelectOptions("Contact Type", dataHelper.Type);
            EnterText("Address Line 1", dataHelper.AddressLine1);
            EnterText("Address Line 2", dataHelper.AddressLine2);
            EnterText("Address Line 3", dataHelper.AddressLine3);
            EnterText("City", dataHelper.City);
            EnterText("Postcode", dataHelper.Postcode);

            return this;
        }
    }
}
