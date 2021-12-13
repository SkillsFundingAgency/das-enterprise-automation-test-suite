using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class EqualityAndDiversityPolicyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's equality and diversity policy";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public EqualityAndDiversityPolicyPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EqualityAndDiversityPolicyFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }
}
