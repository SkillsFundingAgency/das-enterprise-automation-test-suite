using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class UploadOrganisationPolicyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's policy for professional development of employees";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public UploadOrganisationPolicyPage(ScenarioContext context) : base(context) => VerifyPage();

        public GiveAnExampleToImproveEmployeesPage UploadOrganisationPolicyAndContinue()
        {
            UploadFile();
            return new GiveAnExampleToImproveEmployeesPage(context);
        }
    }
}