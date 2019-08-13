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
    internal sealed class ApplicationPage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "APPLICATION";
        private const string ExpectedSoYouHaveFoundTheApprenticeshipSectionHeader = "SO, YOU'VE FOUND THE APPRENTICESHIP YOU'D LIKE TO APPLY FOR?";
        private const string ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph1 = "Once you've searched and found the right apprenticeship for you, you can get on with the application process.";
        private const string ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph2 = "If you haven't found your ideal apprenticeship yet, you can search for the latest apprenticeship vacancies by job title or employer, or just browse to see what’s available in your area.";
        private const string ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph3 = "You can then manage your applications and even get alerts about new apprenticeships.";
        private const string ExpectedAppliyForTheJobHeader = "APPLY FOR THE JOB AND SEND THE APPLICATION TO THE EMPLOYER";
        private const string ExpectedAppliyForTheJobParagraph1 = "Get help with writing applications, creating a good CV and covering letter.";
        private const string ExpectedWaitForTheApplicationsHeader = "WAIT FOR THE APPLICATIONS TO BE SHORTLISTED";
        private const string ExpectedWaitForTheApplicationsParagraph1 = "If you haven’t applied for many jobs before, this can be the nail-biting bit, where you're waiting to hear back from the employer. Sometimes it might help to check when the closing date was for applications - this should give you a clue as to when they'll be in touch.";
        private const string ExpectedWaitForTheApplicationsParagraph2 = "It's a good idea to apply for more than one apprenticeship vacancy at one time. Try and get a number of applications to potential employers; that way you're increasing your options and not waiting for a response from one employer.";
        private const string ExpectedWaitForTheApplicationsParagraph3 = "If you don't get an interview, don't take it personally. It's usual to apply for a number of vacancies before you find the right apprenticeship for you. This happens to everyone and it's part of the normal process.";
        private const string ExpectedIfYouAreOnTheShortlistHeader = "IF YOU’RE ON THE SHORTLIST, YOU’LL BE INVITED FOR AN INTERVIEW WITH THE EMPLOYER";
        private const string ExpectedIfYouAreOnTheShortlistParagraph1 = "This first interview could be an online chat or video call, rather than a face-to-face one. Remember to brush up your research into the organisation for each stage of the interview process.";
        private const string ExpectedTrainingProvidersHeader = "TRAINING PROVIDERS";
        private const string ExpectedTrainingProvidersParagraph1 = "Your employer will find a training provider that is best suited to deliver the training for your apprenticeship. Some training providers also offer support to help you apply for an apprenticeship.";
        private const string ExpectedTrainingProvidersParagraph2 = "Your teacher or careers adviser can help you find out about training providers and how to get in touch. There are also other local organisations that can help you find out more, like a job centre or other community programmes.";
        private const string hyperLink1 = "https://www.findapprenticeship.service.gov.uk/apprenticeshipsearch";
        private const string hyperLink2 = "https://nationalcareers.service.gov.uk/get-a-job/cv-sections";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        private IList<string> hyperLinkList = new List<string>(); 
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _soYouHaveFoundTheApprenticeshipHeader = By.XPath("//div[@class='page']/h2");
        private readonly By _soYouHaveFoundTheApprenticeshipParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _soYouHaveFoundTheApprenticeshipParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _soYouHaveFoundTheApprenticeshipParagraph3 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _applyForTheJobHeader = By.XPath("//div[@class='page']/h3[1]");
        private readonly By _applyForTheJobParagraph1 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _waitForTheApplicationHeader = By.XPath("//div[@class='page']/h3[2]");
        private readonly By _waitForTheApplicationParagraph1 = By.XPath("//div[@class='page']/p[5]");
        private readonly By _waitForTheApplicationParagraph2 = By.XPath("//div[@class='page']/p[6]");
        private readonly By _waitForTheApplicationParagraph3 = By.XPath("//div[@class='page']/p[7]");
        private readonly By _ifYouAreOnTheShortlistHeader = By.XPath("//div[@class='page']/h3[3]");
        private readonly By _ifYouAreOnTheShortlistParagraph1 = By.XPath("//div[@class='page']/p[8]");
        private readonly By _trainingProvidersHeader = By.XPath("//div[@class='page']/h3[4]");
        private readonly By _trainingProvidersParagraph1 = By.XPath("//div[@class='page']/p[9]");
        private readonly By _trainingProvidersParagraph2 = By.XPath("//div[@class='page']/p[10]");
        private readonly By _anchorElement = By.TagName("a");
        #endregion

        public ApplicationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(_pageTitle, ExpectedPageTitle);
        }

        internal void verifyContentUnderSoYouHaveFoundTheApprenticeshipSection()
        {
            string actualSoYouHaveFoundTheApprenticeshipHeader = _pageInteractionHelper.GetText(_soYouHaveFoundTheApprenticeshipHeader);
            string actualSoYouHaveFoundTheApprenticeshipParagraph1 = _pageInteractionHelper.GetText(_soYouHaveFoundTheApprenticeshipParagraph1);
            string actualSoYouHaveFoundTheApprenticeshipParagraph2 = _pageInteractionHelper.GetText(_soYouHaveFoundTheApprenticeshipParagraph2);
            string actualSoYouHaveFoundTheApprenticeshipParagraph3 = _pageInteractionHelper.GetText(_soYouHaveFoundTheApprenticeshipParagraph3);

            _pageInteractionHelper.VerifyText(actualSoYouHaveFoundTheApprenticeshipHeader, ExpectedSoYouHaveFoundTheApprenticeshipSectionHeader);
            _pageInteractionHelper.VerifyText(actualSoYouHaveFoundTheApprenticeshipParagraph1, ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph1);
            _pageInteractionHelper.VerifyText(actualSoYouHaveFoundTheApprenticeshipParagraph2, ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph2);
            _pageInteractionHelper.VerifyText(actualSoYouHaveFoundTheApprenticeshipParagraph3, ExpectedSoYouHaveFoundTheApprenticeshipSectionParagraph3);
        }

        internal void verifyContentUnderApplyForTheJobSection()
        {
            string actualApplyForTheJobHeader = _pageInteractionHelper.GetText(_applyForTheJobHeader);
            string actualApplyForTheJobParagraph1 = _pageInteractionHelper.GetText(_applyForTheJobParagraph1);

            _pageInteractionHelper.VerifyText(actualApplyForTheJobHeader, ExpectedAppliyForTheJobHeader);
            _pageInteractionHelper.VerifyText(actualApplyForTheJobParagraph1, ExpectedAppliyForTheJobParagraph1);
        }

        internal void verifyContentUnderWaitForTheApplicationSection()
        {
            string actualWaitForTheApplicationHeader = _pageInteractionHelper.GetText(_waitForTheApplicationHeader);
            string actualWaitForTheApplicationParagraph1 = _pageInteractionHelper.GetText(_waitForTheApplicationParagraph1);
            string actualWaitForTheApplicationParagraph2 = _pageInteractionHelper.GetText(_waitForTheApplicationParagraph2);
            string actualWaitForTheApplicationParagraph3 = _pageInteractionHelper.GetText(_waitForTheApplicationParagraph3);

            _pageInteractionHelper.VerifyText(actualWaitForTheApplicationHeader, ExpectedWaitForTheApplicationsHeader);
            _pageInteractionHelper.VerifyText(actualWaitForTheApplicationParagraph1, ExpectedWaitForTheApplicationsParagraph1);
            _pageInteractionHelper.VerifyText(actualWaitForTheApplicationParagraph2, ExpectedWaitForTheApplicationsParagraph2);
            _pageInteractionHelper.VerifyText(actualWaitForTheApplicationParagraph3, ExpectedWaitForTheApplicationsParagraph3);
        }

        internal void verifyContentUnderIfYouAreOnTheShortlistSection()
        {
            string actualIfYouAreOnTheShortlistHeader = _pageInteractionHelper.GetText(_ifYouAreOnTheShortlistHeader);
            string actualIfYouAreOnTheShortlistParagraph1 = _pageInteractionHelper.GetText(_ifYouAreOnTheShortlistParagraph1);

            _pageInteractionHelper.VerifyText(actualIfYouAreOnTheShortlistHeader, ExpectedIfYouAreOnTheShortlistHeader);
            _pageInteractionHelper.VerifyText(actualIfYouAreOnTheShortlistParagraph1, ExpectedIfYouAreOnTheShortlistParagraph1);
        }

        internal void verifyContentUnderTrainingProvidersSection()
        {
            string actualTrainingProvidersHeader = _pageInteractionHelper.GetText(_trainingProvidersHeader);
            string actualTrainingProvidersParagraph1 = _pageInteractionHelper.GetText(_trainingProvidersParagraph1);
            string actualTrainingProvidersParagraph2 = _pageInteractionHelper.GetText(_trainingProvidersParagraph2);

            _pageInteractionHelper.VerifyText(actualTrainingProvidersHeader, ExpectedTrainingProvidersHeader);
            _pageInteractionHelper.VerifyText(actualTrainingProvidersParagraph1, ExpectedTrainingProvidersParagraph1);
            _pageInteractionHelper.VerifyText(actualTrainingProvidersParagraph2, ExpectedTrainingProvidersParagraph2);
        }

    }
}
