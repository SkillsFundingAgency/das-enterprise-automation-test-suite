using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionAssessmentAndCertification
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private AssessmentAndCertificationPage assessmentAndCertificationPage;
        #endregion

        public StepDefinitionAssessmentAndCertification(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
            assessmentAndCertificationPage = new AssessmentAndCertificationPage(_context);
        }

        [Then(@"I verify the content under Get assured and get your certificate section")]
        public void VerifyContentUnderWhatToBringSection()
        {
            assessmentAndCertificationPage.VerifyContentUnderGetAssessedAndGetYourCertificateSection();
        }

        [Then(@"I verify the content under Complete your apprenticeship section")]
        public void VerifyCompleteYourAppremnticeshiSection()
        {
            assessmentAndCertificationPage.VerifyContentUnderCompleteYourApprenticeshipSection();
        }

    }
}