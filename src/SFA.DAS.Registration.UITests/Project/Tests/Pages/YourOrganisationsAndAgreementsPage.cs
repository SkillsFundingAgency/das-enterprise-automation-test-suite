using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";
        private readonly ScenarioContext _context;

        #region Locators
        protected override string Linktext => "Your organisations and agreements";
        private By TransferStatus => By.ClassName("transfers-status");
        private By AgreementId => By.CssSelector("table tbody tr td[data-label='Agreement ID']");
        private By AddNewOrganisationButton => By.Id("addNewOrg");
        private By TableCells => By.XPath("//td");
        private By ViewAgreementLink => By.LinkText("View");
        private By RemoveAnOrgFromYourAccountLink => By.LinkText("Remove an organisation from your account");
        private By OrgRemovedMessageInHeader = By.CssSelector("h1");
        #endregion

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
        }

        public string GetTransfersStatus() => pageInteractionHelper.GetText(TransferStatus);

        public void SetAgreementId()
        {
            var agreementId = pageInteractionHelper.GetText(AgreementId);
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

        public RemoveAnOrganisationPage ClickOnRemoveAnOrgFromYourAccountLink()
        {
            formCompletionHelper.Click(RemoveAnOrgFromYourAccountLink);
            return new RemoveAnOrganisationPage(_context);
        }

        public bool VerifyOrgRemovedMessageInHeader() => pageInteractionHelper.VerifyText(OrgRemovedMessageInHeader, $"You have removed {objectContext.GetOrganisationName()}");
    }
}