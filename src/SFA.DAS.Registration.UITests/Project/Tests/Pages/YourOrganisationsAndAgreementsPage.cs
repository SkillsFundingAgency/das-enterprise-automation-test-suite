using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";
        private readonly ScenarioContext _context;
        private readonly TableRowHelper _tableRowHelper;

        #region Locators
        protected override string Linktext => "Your organisations and agreements";
        private By TransferStatus => By.ClassName("transfers-status");
        private By AgreementId => By.CssSelector("table tbody tr td[data-label='Agreement ID']");
        private By AddNewOrganisationButton => By.Id("addNewOrg");
        private By TableCells => By.XPath("//td");
        #endregion

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _tableRowHelper = context.Get<TableRowHelper>();
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

        public bool VerifyNewlyAddedOrgIsPresent()
            => pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(objectContext.GetOrganisationName());
    }
}