using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class RemoveAnOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Remove an organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By CantBeRemovedMessageText => By.XPath("//td[text()=\"Can't be removed because it's the only organisation on your account.\"]");
        private By RemoveLinkBesideNewlyAddedOrg => By.XPath($"//td[text()='{objectContext.GetOrganisationName()}']/following-sibling::td/a");
        #endregion

        public RemoveAnOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RemoveAnOrganisationPage VerifyCantBeRemovedMessageTextOnRemoveAnOrganisationPage()
        {
            VerifyPage(CantBeRemovedMessageText);
            return this;
        }

        public RemoveOrganisationPage ClickOnRemoveLinkBesideNewlyAddedOrgInRemoveAnOrganisationPage()
        {
            formCompletionHelper.Click(RemoveLinkBesideNewlyAddedOrg);
            return new RemoveOrganisationPage(_context);
        }
    }
}