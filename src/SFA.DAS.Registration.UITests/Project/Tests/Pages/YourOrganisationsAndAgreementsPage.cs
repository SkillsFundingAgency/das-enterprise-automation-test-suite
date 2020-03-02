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

        public OrganisationSearchPage ClickAddNewOrganisationButton()
        {
            formCompletionHelper.Click(AddNewOrganisationButton);
            return new OrganisationSearchPage(_context);
        }

        public void VerifyNewlyAddedOrgIsPresent() =>
            Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(objectContext.GetOrganisationName()),
                $"'{objectContext.GetOrganisationName()} is NOT listed under 'YourOrganisationsAndAgreementsPage'");

        public YourEsfaAgreementPage ClickViewAgreementLink()
        {
            formCompletionHelper.Click(ViewAgreementLink);
            return new YourEsfaAgreementPage(_context);
        }
    }
}