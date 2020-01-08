using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";

        protected override string Linktext => "Your organisations and agreements";

        private By TransferStatus => By.ClassName("transfers-status");

        private By AgreementId => By.CssSelector("table tbody tr td[data-label='Agreement ID']");

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
        }

        public string GetTransfersStatus()
        {
            return pageInteractionHelper.GetText(TransferStatus);
        }

        public void SetAgreementId()
        {
            var agreementId = pageInteractionHelper.GetText(AgreementId);

            objectContext.SetAgreementId(agreementId);
        }
    }
}