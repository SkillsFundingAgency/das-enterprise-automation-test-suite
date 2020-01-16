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
    internal sealed class InterviewPage : BasePage
    {
        protected override string PageTitle => "INTERVIEW";
        protected override By PageHeader => _pageTitle;
        #region Constants
        private const string ExpectedTheInterviewProcessHeader = "THE INTERVIEW PROCESS";
        private const string ExpectedTheInterviewProcessParagraph1 = "Everyone goes through the interview process at some stage of their working life. When you apply for new jobs, you will almost always have an interview, whatever stage you're at in your career.";
        private const string ExpectedTheInterviewProcessParagraph2 = "If you want to upskill or are returning to the workplace after a break, you may already know how to prepare for an interview and what you're expected to take with you on your first day.";
        private const string ExpectedTheInterviewProcessParagraph3 = "If that's the case, then all you need to do is Find an apprenticeship.";
        private const string ExpectedTheInterviewProcessParagraph4 = "If you’re planning on working for bigger organisations, you might have two or three interviews. A smaller employer may just want to meet you face-to-face, to see if you fit into their organisation.";
        private const string ExpectedTheInterviewProcessParagraph5 = "Employers will each set their own application process for an apprenticeship, which will be similar to applying for any other job within that organisation. This typically, will involve an interview.";
        private const string ExpectedTheInterviewProcessParagraph6 = "Interviews can range from face-to-face, a panel interview, on the telephone or online. It just depends on how the employer wants to conduct it.";
        private const string ExpectedTheInterviewProcessParagraph7 = "If you've not done an interview before, the following tips should help you through the whole process:";
        private const string ExpectedBeforeYourInterviewHeader = "BEFORE YOUR INTERVIEW";
        private const string ExpectedCheckWhereAndWhenSubHeader1 = "CHECK WHERE AND WHEN";
        private const string ExpectedCheckWhereAndWhenParagraph1 = "Find out what time your interview is, then figure out the best way to get there in plenty of time. Also check the employer’s website for the address, directions and any useful advice on finding their premises.";
        private const string ExpectedKnowYourStuffSubHeader2 = "KNOW YOUR STUFF";
        private const string ExpectedKnowYourStuffParagraph1 = "It’s worth finding out as much as you can about the apprenticeship, and the organisation that's interviewing you. You might also want to keep up to date with the relevant news in your industry, just in case your interviewer asks your opinions on any relevant news stories.";
        private const string ExpectedPracticeSubHeader3 = "PRACTICE";
        private const string ExpectedPracticeParagraph1 = "Try a mock interview with a teacher, adviser or even a friend. A simple practice interview can help you feel more confident, and see what questions and answers you need to practice.";
        private const string ExpectedPracticeParagraph2 = "Remember to include a few questions that you think you might be asked e.g. Why you chose this apprenticeship, what you enjoy most about your current studies.";
        private const string ExpectedDayOfTheInterviewHeader = "DAY OF THE INTERVIEW";
        private const string ExpectedWhatToWearSubHeader1 = "WHAT TO WEAR";
        private const string ExpectedWhatToWearParagraph1 = "You don’t necessarily need to wear a suit, but smart trousers or a skirt and a shirt or blouse will show you're taking it seriously.";
        private const string ExpectedGetThereEarlySubHeader2 = "GET THERE EARLY";
        private const string ExpectedGetThereEarlyParagraph1 = "Especially if you’re using public transport. Look to arrive between 10 and 15 mins before your interview time, and make sure you have their phone number handy so you can let them know if you're delayed. Remember, being on time and reliable could be the first thing they learn about you.";
        private const string ExpectedGoodBodyLanguageSubHeader3 = "GOOD BODY LANGUAGE";
        private const string ExpectedGoodBodyLanguageParagraph1 = "Try not to slouch, yawn or fold your arms. Stay calm and alert, sit up straight and make eye contact. Whoever is interviewing you will know you’re nervous and not necessarily used to being asked interview questions.";
        private const string ExpectedDonotWorryIfYouDonotUnderstandSubHeader4 = "DON'T WORRY IF YOU DON'T UNDERSTAND";
        private const string ExpectedDonotWorryIfYouDonotUnderstandParagraph2 = "Ask them to repeat or rephrase the question. If you're still unsure make a good guess, or relate it to something you know better.";
        private const string ExpectedAskThemQuestionsTooSubHeader5 = "ASK THEM QUESTIONS TOO";
        private const string ExpectedAskThemQuestionsTooParagraph1 = "This is your apprenticeship too, so make sure you show enthusiasm and prepare a few questions to ask your new potential employer.";
        private const string ExpectedAskThemQuestionsTooParagraph2 = "If you’re the successful candidate, you’ll be offered the apprenticeship by the employer.";
        private const string ExpectedAskThemQuestionsTooParagraph3 = "For more information on preparing for an interview there's a detailed guide on the National Careers Service website.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _theInterviewProcessLink = By.XPath("//ul[@class='list list--arrows']/li[1]/a");
        private readonly By _beforeYourInterviewLink = By.XPath("//ul[@class='list list--arrows']/li[2]/a");
        private readonly By _dayOfTheInterviewLink = By.XPath("//ul[@class='list list--arrows']/li[3]/a");
        private readonly By _theInterviewProcessHeader = By.Id("h1");
        private readonly By _theInterviewProcessParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _theInterviewProcessParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _theInterviewProcessParagraph3 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _theInterviewProcessParagraph4 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _theInterviewProcessParagraph5 = By.XPath("//div[@class='page']/p[5]");
        private readonly By _theInterviewProcessParagraph6 = By.XPath("//div[@class='page']/p[6]");
        private readonly By _theInterviewProcessParagraph7 = By.XPath("//div[@class='page']/p[7]");
        private readonly By _beforeYourInterviewHeader = By.Id("h2");
        private readonly By _checkWhereAndWhenSubHeader1 = By.XPath("//div[@class='page']/h3[1]");
        private readonly By _checkWhereAndWhenParagraph1 = By.XPath("//div[@class='page']/p[8]");
        private readonly By _knowYourStuffSubHeader2 = By.XPath("//div[@class='page']/h3[2]");
        private readonly By _knowYourStuffParagraph1 = By.XPath("//div[@class='page']/p[9]");
        private readonly By _practiceSubHeader3 = By.XPath("//div[@class='page']/h3[3]");
        private readonly By _practiceParagraph1 = By.XPath("//div[@class='page']/p[10]");
        private readonly By _practiceParagraph2 = By.XPath("//div[@class='page']/p[11]");
        private readonly By _dayOfTheInterviewHeader = By.Id("h3");
        private readonly By _whatToWearSubHeader1 = By.XPath("//div[@class='page']/h3[4]");
        private readonly By _whatToWearParagraph1 = By.XPath("//div[@class='page']/p[12]");
        private readonly By _getThereEarlySubHeader2 = By.XPath("//div[@class='page']/h3[5]");
        private readonly By _getThereEarlyParagraph1 = By.XPath("//div[@class='page']/p[13]");
        private readonly By _goodBodyLanguageSubHeader3 = By.XPath("//div[@class='page']/h3[6]");
        private readonly By _goodBodyLanguageParagraph1 = By.XPath("//div[@class='page']/p[14]");
        private readonly By _donotWorryIfYouDonotUnderstandSubHeader4 = By.XPath("//div[@class='page']/h3[7]");
        private readonly By _donotWorryIfYouDonotUnderstandParagraph1 = By.XPath("//div[@class='page']/p[15]");
        private readonly By _askThemQuestionsTooSubHeader5 = By.XPath("//div[@class='page']/h3[8]");
        private readonly By _askThemQuestionsTooParagraph1 = By.XPath("//div[@class='page']/p[16]");
        private readonly By _askThemQuestionsTooParagraph2 = By.XPath("//div[@class='page']/p[17]");
        private readonly By _askThemQuestionsTooParagraph3 = By.XPath("//div[@class='page']/p[18]");
        #endregion

        public InterviewPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            base.VerifyPage();
        }

        internal void VerifyContentUnderInterviewSection()
        {
            _formCompletionHelper.ClickElement(_theInterviewProcessLink);

            string actualTheInterviewProcessHeader = _pageInteractionHelper.GetText(_theInterviewProcessHeader);
            string actualTheInterviewProcessParagraph1 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph1);
            string actualTheInterviewProcessParagraph2 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph2);
            string actualTheInterviewProcessParagraph3 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph3);
            string actualTheInterviewProcessParagraph4 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph4);
            string actualTheInterviewProcessParagraph5 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph5);
            string actualTheInterviewProcessParagraph6 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph6);
            string actualTheInterviewProcessParagraph7 = _pageInteractionHelper.GetText(_theInterviewProcessParagraph7);

            _pageInteractionHelper.VerifyText(actualTheInterviewProcessHeader, ExpectedTheInterviewProcessHeader);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph1, ExpectedTheInterviewProcessParagraph1);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph2, ExpectedTheInterviewProcessParagraph2);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph3, ExpectedTheInterviewProcessParagraph3);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph4, ExpectedTheInterviewProcessParagraph4);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph5, ExpectedTheInterviewProcessParagraph5);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph6, ExpectedTheInterviewProcessParagraph6);
            _pageInteractionHelper.VerifyText(actualTheInterviewProcessParagraph7, ExpectedTheInterviewProcessParagraph7);

        }

        internal void VerifyContentUnderBeforeYourInterviewSection()
        {
            _pageInteractionHelper.FocusTheElement(_beforeYourInterviewLink);

            string actualBeforeYourInterviewHeader = _pageInteractionHelper.GetText(_beforeYourInterviewHeader);
            string actualCheckWhereAndWhenSubHeader1 = _pageInteractionHelper.GetText(_checkWhereAndWhenSubHeader1);
            string actualCheckWhereAndWhenParagraph1 = _pageInteractionHelper.GetText(_checkWhereAndWhenParagraph1);
            string actualKnowYourStuffSubHeader2 = _pageInteractionHelper.GetText(_knowYourStuffSubHeader2);
            string actualKnowYourStuffParagraph1 = _pageInteractionHelper.GetText(_knowYourStuffParagraph1);
            string actualPracticeSubHeader3 = _pageInteractionHelper.GetText(_practiceSubHeader3);
            string actualPracticeParagraph1 = _pageInteractionHelper.GetText(_practiceParagraph1);
            string actualPracticeParagraph2 = _pageInteractionHelper.GetText(_practiceParagraph2);

            _pageInteractionHelper.VerifyText(actualBeforeYourInterviewHeader, ExpectedBeforeYourInterviewHeader);
            _pageInteractionHelper.VerifyText(actualCheckWhereAndWhenSubHeader1, ExpectedCheckWhereAndWhenSubHeader1);
            _pageInteractionHelper.VerifyText(actualCheckWhereAndWhenParagraph1, ExpectedCheckWhereAndWhenParagraph1);
            _pageInteractionHelper.VerifyText(actualKnowYourStuffSubHeader2, ExpectedKnowYourStuffSubHeader2);
            _pageInteractionHelper.VerifyText(actualKnowYourStuffParagraph1, ExpectedKnowYourStuffParagraph1);
            _pageInteractionHelper.VerifyText(actualPracticeSubHeader3, ExpectedPracticeSubHeader3);
            _pageInteractionHelper.VerifyText(actualPracticeParagraph1, ExpectedPracticeParagraph1);
            _pageInteractionHelper.VerifyText(actualPracticeParagraph2, ExpectedPracticeParagraph2);
        }

        internal void VerifyContentUnderDayOfTheInterviewSection()
        {
            _formCompletionHelper.ClickElement(_dayOfTheInterviewLink);

            string actualDayOfTheInterviewHeader = _pageInteractionHelper.GetText(_dayOfTheInterviewHeader);
            string actualWhatToWearSubHeader1 = _pageInteractionHelper.GetText(_whatToWearSubHeader1);
            string actualWhatToWearParagraph1 = _pageInteractionHelper.GetText(_whatToWearParagraph1);
            string actualGetThereEarlySubHeader2 = _pageInteractionHelper.GetText(_getThereEarlySubHeader2);
            string actualGetThereEarlyParagraph1 = _pageInteractionHelper.GetText(_getThereEarlyParagraph1);
            string actualGoodBodyLanguageSubHeader3 = _pageInteractionHelper.GetText(_goodBodyLanguageSubHeader3);
            string actualGoodBodyLanguageParagraph1 = _pageInteractionHelper.GetText(_goodBodyLanguageParagraph1);
            string actualDonotWorryIfYouDonotUnderstandSubHeader4 = _pageInteractionHelper.GetText(_donotWorryIfYouDonotUnderstandSubHeader4);
            string actualDonotWorryIfYouDonotUnderstandParagraph2 = _pageInteractionHelper.GetText(_donotWorryIfYouDonotUnderstandParagraph1);
            string actualAskThemQuestionsTooSubHeader5 = _pageInteractionHelper.GetText(_askThemQuestionsTooSubHeader5);
            string actualAskThemQuestionsTooParagraph1 = _pageInteractionHelper.GetText(_askThemQuestionsTooParagraph1);
            string actualAskThemQuestionsTooParagraph2 = _pageInteractionHelper.GetText(_askThemQuestionsTooParagraph2);
            string actualAskThemQuestionsTooParagraph3 = _pageInteractionHelper.GetText(_askThemQuestionsTooParagraph3);

            _pageInteractionHelper.VerifyText(actualDayOfTheInterviewHeader, ExpectedDayOfTheInterviewHeader);
            _pageInteractionHelper.VerifyText(actualWhatToWearSubHeader1, ExpectedWhatToWearSubHeader1);
            _pageInteractionHelper.VerifyText(actualWhatToWearParagraph1, ExpectedWhatToWearParagraph1);
            _pageInteractionHelper.VerifyText(actualGetThereEarlySubHeader2, ExpectedGetThereEarlySubHeader2);
            _pageInteractionHelper.VerifyText(actualGetThereEarlyParagraph1, ExpectedGetThereEarlyParagraph1);
            _pageInteractionHelper.VerifyText(actualGoodBodyLanguageSubHeader3, ExpectedGoodBodyLanguageSubHeader3);
            _pageInteractionHelper.VerifyText(actualGoodBodyLanguageParagraph1, ExpectedGoodBodyLanguageParagraph1);
            _pageInteractionHelper.VerifyText(actualDonotWorryIfYouDonotUnderstandSubHeader4, ExpectedDonotWorryIfYouDonotUnderstandSubHeader4);
            _pageInteractionHelper.VerifyText(actualDonotWorryIfYouDonotUnderstandParagraph2, ExpectedDonotWorryIfYouDonotUnderstandParagraph2);
            _pageInteractionHelper.VerifyText(actualAskThemQuestionsTooSubHeader5, ExpectedAskThemQuestionsTooSubHeader5);
            _pageInteractionHelper.VerifyText(actualAskThemQuestionsTooParagraph1, ExpectedAskThemQuestionsTooParagraph1);
            _pageInteractionHelper.VerifyText(actualAskThemQuestionsTooParagraph2, ExpectedAskThemQuestionsTooParagraph2);
            _pageInteractionHelper.VerifyText(actualAskThemQuestionsTooParagraph3, ExpectedAskThemQuestionsTooParagraph3);
        }

    }
}
