using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionAssessmentAndCertification
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly AssessmentAndCertificationPage assessmentAndCertificationPage;
        #endregion

        public StepDefinitionAssessmentAndCertification(ScenarioContext context)
        {
            _context = context;
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