using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";
        private readonly ScenarioContext _context;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;

        #region Locators
        protected override string Linktext => "Your organisations and agreements";
        private By TransferStatus => By.XPath("//p[3]");
        private By AgreementId => By.CssSelector("table tbody tr td[data-label='Agreement ID']");
        private By AddNewOrganisationButton => By.LinkText("Add an organisation");
        private By TableCells => By.XPath("//td");
        private By ViewAgreementLink => By.LinkText("View");
        private By OrgRemovedMessageInHeader = By.Id("error-summary-title");
        private By RemoveLinkBesideNewlyAddedOrg => By.LinkText($"Remove organisation");
        #endregion

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        }

        public string GetTransfersStatus() => pageInteractionHelper.GetText(TransferStatus);

        public void SetAgreementId()
        {
            var agreementId = _registrationSqlDataHelper.GetAgreementId(objectContext.GetAccountId());
            objectContext.SetAgreementId(agreementId);
        }

        public SearchForYourOrganisationPage ClickAddNewOrganisationButton()
        {
            formCompletionHelper.Click(AddNewOrganisationButton);
            return new SearchForYourOrganisationPage(_context);
        }

        public YourOrganisationsAndAgreementsPage VerifyNewlyAddedOrgIsPresent()
        {
            Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(objectContext.GetOrganisationName()),
                $"'{objectContext.GetOrganisationName()} is NOT listed under 'YourOrganisationsAndAgreementsPage'");
            return this;
        }

        public YourEsfaAgreementPage ClickViewAgreementLink()
        {
            formCompletionHelper.Click(ViewAgreementLink);
            return new YourEsfaAgreementPage(_context);
        }

        public AreYouSureYouWantToRemovePage ClickOnRemoveAnOrgFromYourAccountLink()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AreYouSureYouWantToRemovePage(_context);
        }

        public bool IsRemoveLinkBesideNewlyAddedOrg() => pageInteractionHelper.IsElementDisplayed(RemoveLinkBesideNewlyAddedOrg);

        public bool VerifyOrgRemovedMessageInHeader() => pageInteractionHelper.VerifyText(OrgRemovedMessageInHeader, $"You have removed {objectContext.GetOrganisationName()}");
    }
}