using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal class EmployerAssessmentAndCertificationPage:BasePage
    {
       protected override string PageTitle => "ASSESSMENT AND CERTIFICATION";
        protected override By PageHeader => _pageTitle;
        #region Constants
        private const string ExpectedGetAssessedAndGetYourCertificateHeader = "GET ASSESSED AND GET YOUR CERTIFICATE";
        private const string ExpectedAssessedLink = "Assessment";
        private const string ExpectedWhereToFindAnEndPointAssessmentOrganisationLink = "Where to find an end-point assessment organisation";
        
        private const string ExpectedCompleteYourApprenticeshipHeader = "COMPLETE YOUR APPRENTICESHIP";
        private const string ExpectedCompleteYourApprenticeshipParagraph1 = "Pass the assessment, finish your apprenticeship, enjoy the moment (then jump around, scream, shout, post something on social media). You’ve done it, you did it, you’ve earned this!";
        private const string ExpectedCompleteYourApprenticeshipParagraph2 = "So, where next?";
        private const string ExpectedCompleteYourApprenticeshipParagraph3 = "Just like your apprenticeship, the answer’s up to you. You’ve got a whole new set of skills, an apprenticeship that’ll impress employers, and really useful experiences that show that you can make the step up from apprentice to, well, wherever you want to go.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _assessmentLink = By.XPath("//ul[@class='list list--arrows']/li[1]");
        private readonly By _whereToFindAnEndPointAssessmentOrganisationLink = By.XPath("//ul[@class='list list--arrows']/li[2]");
        
        
        private readonly By _getAssessedAndGetYourCertificateHeader = By.Id("h1");
        private readonly By _getAssessedAndGetYourCertificateParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _getAssessedAndGetYourCertificateParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _completeYourApprenticeshipHeader = By.Id("h2");
        private readonly By _completeYourApprenticeshipParagraph1 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _completeYourApprenticeshipParagraph2 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _completeYourApprenticeshipParagraph3 = By.XPath("//div[@class='page']/p[5]");
        #endregion

        public EmployerAssessmentAndCertificationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public void CheckEmployerAssessmentAndCertificationContent()
        {
            _pageInteractionHelper.VerifyText(_assessmentLink,ExpectedAssessedLink);
            _pageInteractionHelper.VerifyText(_whereToFindAnEndPointAssessmentOrganisationLink,ExpectedWhereToFindAnEndPointAssessmentOrganisationLink);
        }
    }
}