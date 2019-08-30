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
    internal sealed class WhatIsAnApprenticeshipPage : BasePage
    {
        protected override string PageTitle => "WHAT IS AN APPRENTICESHIP?";
        protected override By PageHeader => _pageTitle;
        #region Constants
        private const string ExpectedWhatIsAnApprenticeshipParagraph1 = "It’s a real job, with hands-on experience, a salary and the chance to train while you work. You’re treated just like all the other employees, with a contract of employment and holiday leave.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph2 = "If you’re 16 or over, you can become an apprentice as long as you spend at least 50% of your working hours in England - for the duration of the apprenticeship and you are not in full-time education.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph3 = "If you live in Scotland, Wales, or Northern Ireland, check out your apprenticeship options.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph4 = "When you're an apprentice:";
        private const string ExpectedWhenYouAreApprenticeBP1 = "you get paid and train at the same time, with at least 20% of your time spent in off the job training, often at a college, university or with a training provider";
        private const string ExpectedWhenYouAreApprenticeBP2 = "you train to be fully competent in your chosen occupation";
        private const string ExpectedWhenYouAreApprenticeBP3 = "you’re on a career path - with lots of future potential for you";
        private const string ExpectedWhatIsAnApprenticeshipParagraph5 = "Your apprenticeship can take between one and six years to complete, depending on which apprenticeship you choose, what level it’s at, and your previous experience.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph6 = "Different apprenticeships are available all over England, at companies large and small, in a wide range of industries and organisations. From local organisations to large national brands.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph7 = "You get valuable hands-on experience working whilst you learn, which helps you progress in your working life.";
        private const string ExpectedWhatIsAnApprenticeshipParagraph8 = "Completing your apprenticeship means you've earned and learned. Given your training is funded by contributions from the government and your employer, and you receive a regular salary, apprenticeships are a great option for getting on the job ladder or supercharging your career.";
        private const string ExpectedDifferentTypesOfApprenticeshipsHeader = "WHAT ARE THE DIFFERENT TYPES OF APPRENTICESHIPS?";
        private const string ExpectedDifferentTypesOfApprenticeshipsParagraph1 = "There are hundreds of different apprenticeships to choose from. Whether you’re at the start of your career, want to change career direction, or if you’re returning to work after a break.";
        private const string ExpectedDifferentTypesOfApprenticeshipsParagraph2 = "All apprenticeships make sure you're ‘job ready’ for the role you have trained for.";
        private const string ExpectedDifferentTypesOfApprenticeshipsParagraph3 = "Apprentices earn a salary right from day one of their employment and training.";
        private const string ExpectedDifferentTypesOfApprenticeshipsParagraph4 = "If you think you need better skills and need more work experience so that you're ready to apply for your chosen apprenticeship - you could consider doing a traineeship.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        private IList<string> actualWhenYouAreApprenticeBPList = new List<string>();
        private IList<string> expectedWhenYouAreApprenticeBPList = new List<string>();
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _differentTypesOfApprebticeshipsLink = By.ClassName("hero__link");    
        private readonly By _whatIsAnApprenticeshipParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _whatIsAnApprenticeshipParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _whatIsAnApprenticeshipParagraph3 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _whatIsAnApprenticeshipParagraph4 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _whatIsAnApprenticeshipParagraph5 = By.XPath("//div[@class='page']/p[5]");
        private readonly By _whatIsAnApprenticeshipParagraph6 = By.XPath("//div[@class='page']/p[6]");
        private readonly By _whatIsAnApprenticeshipParagraph7 = By.XPath("//div[@class='page']/p[7]");
        private readonly By _whatIsAnApprenticeshipParagraph8 = By.XPath("//div[@class='page']/p[8]");
        private readonly By _differentTypesOfApprenticeshipsHeader = By.XPath("//div[@class='page']/h2");
        private readonly By _differentTypesOfApprenticeshipsParagraph1 = By.XPath("//div[@class='page']/p[9]");
        private readonly By _differentTypesOfApprenticeshipsParagraph2 = By.XPath("//div[@class='page']/p[10]");
        private readonly By _differentTypesOfApprenticeshipsParagraph3 = By.XPath("//div[@class='page']/p[11]");
        private readonly By _differentTypesOfApprenticeshipsParagraph4 = By.XPath("//div[@class='page']/p[12]");
        #endregion

        public WhatIsAnApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            base.VerifyPage();
        }

        internal void VerifyContentUnderWhatIsAnApprenticeshipSection()
        {
            expectedWhenYouAreApprenticeBPList.Add(ExpectedWhenYouAreApprenticeBP1);
            expectedWhenYouAreApprenticeBPList.Add(ExpectedWhenYouAreApprenticeBP2);
            expectedWhenYouAreApprenticeBPList.Add(ExpectedWhenYouAreApprenticeBP3);

            for (int i = 1; i <= 3; i++)
            {
                actualWhenYouAreApprenticeBPList.Add(_pageInteractionHelper.GetText(By.XPath("//div[@class='page']/ul[1]/li[" + i + "]")));
            }

            string actualWhatIsAnApprenticeshipParagraph1 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph1);
            string actualWhatIsAnApprenticeshipParagraph2 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph2);
            string actualWhatIsAnApprenticeshipParagraph3 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph3);
            string actualWhatIsAnApprenticeshipParagraph4 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph4);
            string actualWhatIsAnApprenticeshipParagraph5 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph5);
            string actualWhatIsAnApprenticeshipParagraph6 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph6);
            string actualWhatIsAnApprenticeshipParagraph7 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph7);
            string actualWhatIsAnApprenticeshipParagraph8 = _pageInteractionHelper.GetText(_whatIsAnApprenticeshipParagraph8);

            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph1, ExpectedWhatIsAnApprenticeshipParagraph1);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph2, ExpectedWhatIsAnApprenticeshipParagraph2);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph3, ExpectedWhatIsAnApprenticeshipParagraph3);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph4, ExpectedWhatIsAnApprenticeshipParagraph4);
            _pageInteractionCampaignsHelper.CompareContentOfAnyTwoLists(actualWhenYouAreApprenticeBPList, expectedWhenYouAreApprenticeBPList);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph5, ExpectedWhatIsAnApprenticeshipParagraph5);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph6, ExpectedWhatIsAnApprenticeshipParagraph6);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph7, ExpectedWhatIsAnApprenticeshipParagraph7);
            _pageInteractionHelper.VerifyText(actualWhatIsAnApprenticeshipParagraph8, ExpectedWhatIsAnApprenticeshipParagraph8);
        }


        internal void VerifyContentUnderDifferentTypesOfApprenticeshipsSection()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_differentTypesOfApprebticeshipsLink);
            _formCompletionHelper.ClickElement(_differentTypesOfApprebticeshipsLink);

            string actualDifferentTypesOfApprenticeshipsHeader = _pageInteractionHelper.GetText(_differentTypesOfApprenticeshipsHeader);
            string actualDifferentTypesOfApprenticeshipsParagraph1 = _pageInteractionHelper.GetText(_differentTypesOfApprenticeshipsParagraph1);
            string actualDifferentTypesOfApprenticeshipsParagraph2 = _pageInteractionHelper.GetText(_differentTypesOfApprenticeshipsParagraph2);
            string actualDifferentTypesOfApprenticeshipsParagraph3 = _pageInteractionHelper.GetText(_differentTypesOfApprenticeshipsParagraph3);
            string actualDifferentTypesOfApprenticeshipsParagraph4 = _pageInteractionHelper.GetText(_differentTypesOfApprenticeshipsParagraph4);

            _pageInteractionHelper.VerifyText(actualDifferentTypesOfApprenticeshipsHeader, ExpectedDifferentTypesOfApprenticeshipsHeader);
            _pageInteractionHelper.VerifyText(actualDifferentTypesOfApprenticeshipsParagraph1, ExpectedDifferentTypesOfApprenticeshipsParagraph1);
            _pageInteractionHelper.VerifyText(actualDifferentTypesOfApprenticeshipsParagraph2, ExpectedDifferentTypesOfApprenticeshipsParagraph2);
            _pageInteractionHelper.VerifyText(actualDifferentTypesOfApprenticeshipsParagraph3, ExpectedDifferentTypesOfApprenticeshipsParagraph3);
            _pageInteractionHelper.VerifyText(actualDifferentTypesOfApprenticeshipsParagraph4, ExpectedDifferentTypesOfApprenticeshipsParagraph4);
        }

    }
}
