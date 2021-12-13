using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CertificateDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Certificate";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By DeleteCertificateLink => By.LinkText("Delete certificate");

        public CertificateDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AreYouSureYouWantToDeletePage ClickDeleteCertificateLink()
        {
            formCompletionHelper.ClickElement(DeleteCertificateLink);
            return new AreYouSureYouWantToDeletePage(_context);
        }
    }
}