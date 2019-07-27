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
    internal sealed class YourApprenticeshipPage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "";
        private const string ExpectedWhatToBringHeader = "WHAT TO BRING, AND OTHER USEFUL INFO";
        private const string ExpectedWhatToBringParagraph1 = "Your employer will be in touch beforehand to let you know your working hours, and when they’d like you to start on your first day. If however, you already work at the place where you're going to start your apprenticeship, then you can ask your employer directly.";
        private const string ExpectedWhatToBringParagraph2 = "At this point you could also ask some of the following:";
        private const string ExpectedMeetYourNewTeamHeader = "MEET YOUR NEW TEAM";
        private const string ExpectedMeetYourNewTeamParagraph1 = "When you start your apprenticeship, you’ll meet the people you'll be working with. They will show you around and answer any questions you might have.";
        private const string ExpectedWhatComesAfterMyApprenticeshipHeader = "WHAT COMES AFTER MY APPRENTICESHIP?";
        private const string ExpectedWhatComesAfterMyApprenticeshipParagraph1 = "Apprenticeships are designed to make you ‘job-ready’ in the role you're training for. Once your apprenticeship is up and running, and you’re gaining more experience and learning new skills, you can start to plan for the next step.";
        private const string ExpectedWhatComesAfterMyApprenticeshipParagraph2 = "Most apprentices stay on in employment or further training after their apprenticeship. It’s always worth discussing your future career with your current employer, as well as doing some research yourself.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        //private readonly MainNavigationHelper mainNavigationHelper;
        private ArrayList actualQuestionsList = new ArrayList();
        private ArrayList expectedQuestionsList = new ArrayList();

        #endregion

        #region Page Object Elements
        private readonly By _whatToBringLink = By.XPath("//ul[@class='list list--arrows']/li[1]/a");
        private readonly By _meetYourNewTeamLink = By.XPath("//ul[@class='list list--arrows']/li[2]/a");
        private readonly By _whatComesAfterMyApprenticeshipLink = By.XPath("//ul[@class='list list--arrows']/li[3]/a");
        private readonly By _whatToBringHeader = By.Id("h1");
        private readonly By _whatToBringParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _whatToBringParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _whatToBringQuestions = By.XPath("//div[@class='page']/ul[1]/li");
        private readonly By _meetYourNewTeamHeader = By.Id("h2");
        private readonly By _meetYourNewTeamParagraph1 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _whatComesAfterMyApprenticeshipHeader = By.Id("h3");
        private readonly By _whatComesAfterMyApprenticeshipParagraph1 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _whatComesAfterMyApprenticeshipParagraph2 = By.XPath("//div[@class='page']/p[5]");
        #endregion

        public YourApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), ExpectedPageTitle);
        }

        internal bool IsPageMatching()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), ExpectedPageTitle);
        }

        internal void verifyConetntUnderWhatToBringSection()
        {
            expectedQuestionsList.Add("what you will need to bring - notebook/pens/ID");
            expectedQuestionsList.Add("what time you need to arrive");
            expectedQuestionsList.Add("how your should dress - suit or jeans");
            expectedQuestionsList.Add("how much money you will need to bring for lunch etc");
            expectedQuestionsList.Add("who you should ask for when you arrive");
            expectedQuestionsList.Add("where to get the bus/train or park your car");

            _pageInteractionHelper.WaitForElementToBeDisplayed(_whatToBringLink);
            _formCompletionHelper.ClickElement(_whatToBringLink);
            System.Threading.Thread.Sleep(5000);
            string actualWhatToBringHeader = _pageInteractionHelper.GetText(_whatToBringHeader);
            string actualWhatToBringParagraph1 = _pageInteractionHelper.GetText(_whatToBringParagraph1);
            string actualWhatToBringParagraph2 = _pageInteractionHelper.GetText(_whatToBringParagraph2);
            for (int i=1; i<=6; i++)
            {
                actualQuestionsList.Add(_pageInteractionHelper.GetText(By.XPath("//div[@class='page']/ul[1]/li[" + i + "]")));
            }

            _pageInteractionHelper.VerifyText(actualWhatToBringHeader, ExpectedWhatToBringHeader);
            _pageInteractionHelper.VerifyText(actualWhatToBringParagraph1, ExpectedWhatToBringParagraph1);
            _pageInteractionHelper.VerifyText(actualWhatToBringParagraph2, ExpectedWhatToBringParagraph2);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& "+actualQuestionsList.Equals(expectedQuestionsList));
        }

        internal void verifyContentUnderMeetYourNewTeamSection()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_meetYourNewTeamLink);
            //_formCompletionHelper.ClickElement(_meetYourNewTeamLink);
            string actualMeetYourNewTeamHeader = _pageInteractionHelper.GetText(_meetYourNewTeamHeader);
            string actualMeetYourNewTeamParagraph1 = _pageInteractionHelper.GetText(_meetYourNewTeamParagraph1);
            _pageInteractionHelper.VerifyText(actualMeetYourNewTeamHeader, ExpectedMeetYourNewTeamHeader);
            _pageInteractionHelper.VerifyText(actualMeetYourNewTeamParagraph1, ExpectedMeetYourNewTeamParagraph1);
        }

        internal void verifyContentUnderWhatComesAfterMyApprenticeshipSection()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_whatComesAfterMyApprenticeshipLink);
            //_formCompletionHelper.ClickElement(_whatComesAfterMyApprenticeshipLink);
            string actualWhatComesAfterMyApprenticeshipHeader = _pageInteractionHelper.GetText(_whatComesAfterMyApprenticeshipHeader);
            string actualWhatComesAfterMyApprenticeshipParagraph1 = _pageInteractionHelper.GetText(_whatComesAfterMyApprenticeshipParagraph1);
            string actualWhatComesAfterMyApprenticeshipParagraph2 = _pageInteractionHelper.GetText(_whatComesAfterMyApprenticeshipParagraph2);
            _pageInteractionHelper.VerifyText(actualWhatComesAfterMyApprenticeshipHeader, ExpectedWhatComesAfterMyApprenticeshipHeader);
            _pageInteractionHelper.VerifyText(actualWhatComesAfterMyApprenticeshipParagraph1, ExpectedWhatComesAfterMyApprenticeshipParagraph1);
            _pageInteractionHelper.VerifyText(actualWhatComesAfterMyApprenticeshipParagraph2, ExpectedWhatComesAfterMyApprenticeshipParagraph2);
        }

    }
}
