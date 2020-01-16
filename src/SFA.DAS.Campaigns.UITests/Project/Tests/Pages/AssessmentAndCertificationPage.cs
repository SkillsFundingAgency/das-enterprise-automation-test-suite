using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class AssessmentAndCertificationPage : BasePage
    {
        protected override string PageTitle => "ASSESSMENT AND CERTIFICATION";
        protected override By PageHeader => _pageTitle;
        #region Constants
        private const string ExpectedGetAssessedAndGetYourCertificateHeader = "GET ASSESSED AND GET YOUR CERTIFICATE";
        private const string ExpectedGetAssessedAndGetYourCertificateParagraph1 = "You will be assessed at some stage during your apprenticeship, to make sure you have achieved the knowledge, skills and behaviours required. Increasingly, many apprenticeships now include an end-point assessment, which will test you at the end of the apprenticeship to make sure you are fully competent in your apprenticeship occupation.";
        private const string ExpectedGetAssessedAndGetYourCertificateParagraph2 = "Your employer and training provider should give you plenty of guidance as to what’s expected, and when your assessment will happen.";
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
        private readonly By _getAssessedAndGetYourCertificateLink = By.XPath("//ul[@class='list list--arrows']/li[1]");
        private readonly By _completeYourApprenticeshipLink = By.XPath("//ul[@class='list list--arrows']/li[1]");
        private readonly By _getAssessedAndGetYourCertificateHeader = By.Id("h1");
        private readonly By _getAssessedAndGetYourCertificateParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _getAssessedAndGetYourCertificateParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _completeYourApprenticeshipHeader = By.Id("h2");
        private readonly By _completeYourApprenticeshipParagraph1 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _completeYourApprenticeshipParagraph2 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _completeYourApprenticeshipParagraph3 = By.XPath("//div[@class='page']/p[5]");
        #endregion

        public AssessmentAndCertificationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            base.VerifyPage();
        }

        internal void VerifyContentUnderGetAssessedAndGetYourCertificateSection()
        {
            _formCompletionHelper.ClickElement(_getAssessedAndGetYourCertificateLink);

            string actualGetAssessedAndGetYourCertificateHeader = _pageInteractionHelper.GetText(_getAssessedAndGetYourCertificateHeader);
            string actualGetAssessedAndGetYourCertificateParagraph1 = _pageInteractionHelper.GetText(_getAssessedAndGetYourCertificateParagraph1);
            string actualGetAssessedAndGetYourCertificateParagraph2 = _pageInteractionHelper.GetText(_getAssessedAndGetYourCertificateParagraph2);

            _pageInteractionHelper.VerifyText(actualGetAssessedAndGetYourCertificateHeader, ExpectedGetAssessedAndGetYourCertificateHeader);
            _pageInteractionHelper.VerifyText(actualGetAssessedAndGetYourCertificateParagraph1, ExpectedGetAssessedAndGetYourCertificateParagraph1);
            _pageInteractionHelper.VerifyText(actualGetAssessedAndGetYourCertificateParagraph2, ExpectedGetAssessedAndGetYourCertificateParagraph2);
        }

        internal void VerifyContentUnderCompleteYourApprenticeshipSection()
        {
            _formCompletionHelper.ClickElement(_completeYourApprenticeshipLink);

            string actualCompleteYourApprenticeshipHeader = _pageInteractionHelper.GetText(_completeYourApprenticeshipHeader);
            string actualCompleteYourApprenticeshipParagraph1 = _pageInteractionHelper.GetText(_completeYourApprenticeshipParagraph1);
            string actualCompleteYourApprenticeshipParagraph2 = _pageInteractionHelper.GetText(_completeYourApprenticeshipParagraph2);
            string actualCompleteYourApprenticeshipParagraph3 = _pageInteractionHelper.GetText(_completeYourApprenticeshipParagraph3);

            _pageInteractionHelper.VerifyText(actualCompleteYourApprenticeshipHeader, ExpectedCompleteYourApprenticeshipHeader);
            _pageInteractionHelper.VerifyText(actualCompleteYourApprenticeshipParagraph1, ExpectedCompleteYourApprenticeshipParagraph1);
            _pageInteractionHelper.VerifyText(actualCompleteYourApprenticeshipParagraph2, ExpectedCompleteYourApprenticeshipParagraph2);
            _pageInteractionHelper.VerifyText(actualCompleteYourApprenticeshipParagraph3, ExpectedCompleteYourApprenticeshipParagraph3);
        }

    }
}
