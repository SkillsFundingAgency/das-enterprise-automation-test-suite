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
    internal sealed class WhatAreTheBenefitsForMePage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "WHAT ARE THE BENEFITS FOR ME?";
        private const string ExpectedWhatAreMyFutureProspectsHeader = "WHAT ARE MY FUTURE PROSPECTS ONCE I’VE SUCCESSFULLY FINISHED MY APPRENTICESHIP?";
        private const string ExpectedWhatAreMyFutureProspectsParagraph1 = "Once you’ve successfully finished, you have plenty of choices. You could apply for another apprenticeship or find a career that uses your new skills.";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2 = "Some of the top reasons for becoming an apprentice:";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP1 = "earn while you learn and get paid a competitive salary";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP2 = "your training is free";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP3 = "choose from hundreds of different apprentice jobs in thousands of organisations";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP4 = "get high quality training paid for by your employer and the government";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP5 = "a great way to get back into the workplace after a career break, or to re-train in a new areas";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP6 = "get a boost to your future earnings potential";
        private const string ExpectedWhatAreMyFutureProspectsParagraph2BP7 = "develop the skills you need for a range of exciting jobs or careers, no matter your age or background";
        private const string ExpectedHowMuchCanYouEarnHeader = "HOW MUCH CAN YOU EARN?";
        private const string ExpectedHowMuchCanYouEarnParagraph1 = "Your salary will depend upon the industry, location and type of apprenticeship you choose.";
        private const string ExpectedHowMuchCanYouEarnParagraph2 = "The minimum wage for an apprentice is £3.90 per hour if you’re aged 16 to 18 - but many employers pay far more than this.";
        private const string ExpectedHowMuchCanYouEarnParagraph3 = "If you’re aged 19 or over and have completed the first year of your apprenticeship, you are entitled to the national minimum wage for your age.";
        private const string ExpectedWhatWillMyApprenticeshipCostMeHeader = "WHAT WILL MY APPRENTICESHIP COST ME?";
        private const string ExpectedWhatWillMyApprenticeshipCostMeParagraph1 = "When you become an apprentice, you’ll need to cover the cost of your day-to-day expenses, such as lunch and travel.";
        private const string ExpectedWhatWillMyApprenticeshipCostMeParagraph2 = "If you’re a care leaver aged 16-24, you’ll receive a £1,000 bursary payment to support you in the first year of your apprenticeship.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        private IList<string> actualWhatAreMyFutureProspectsParagraph2BPList = new List<string>();
        private IList<string> expectedWhatAreMyFutureProspectsParagraph2BPList = new List<string>();
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _whatAreMyFutureProspectsLink = By.XPath("//ul[@class='list list--arrows']/li[1]/a");
        private readonly By _howMuchCanYouEarnLink = By.XPath("//ul[@class='list list--arrows']/li[2]/a");
        private readonly By _whatWillMyApprenticeshipCostMeLink = By.XPath("//ul[@class='list list--arrows']/li[3]/a");
        private readonly By _whatAreMyFutureProspectsHeader = By.Id("h1");
        private readonly By _whatAreMyFutureProspectsParagraph1 = By.XPath("//div[@class='page']/p[1]");
        private readonly By _whatAreMyFutureProspectsParagraph2 = By.XPath("//div[@class='page']/p[2]");
        private readonly By _howMuchCanYouEarnHeader = By.Id("h2");
        private readonly By _howMuchCanYouEarnParagraph1 = By.XPath("//div[@class='page']/p[3]");
        private readonly By _howMuchCanYouEarnParagraph2 = By.XPath("//div[@class='page']/p[4]");
        private readonly By _howMuchCanYouEarnParagraph3 = By.XPath("//div[@class='page']/p[5]");
        private readonly By _whatWillMyApprenticeshipCostMeHeader = By.Id("h3");
        private readonly By _whatWillMyApprenticeshipCostMeParagraph1 = By.XPath("//div[@class='page']/p[6]");
        private readonly By _whatWillMyApprenticeshipCostMeParagraph2 = By.XPath("//div[@class='page']/p[7]");
        #endregion

        public WhatAreTheBenefitsForMePage(ScenarioContext context) : base(context)
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

        internal void verifyContentUnderWhatAreMyFutureProspects()
        {
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP1);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP2);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP3);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP4);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP5);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP6);
            expectedWhatAreMyFutureProspectsParagraph2BPList.Add(ExpectedWhatAreMyFutureProspectsParagraph2BP7);

            _pageInteractionHelper.WaitForElementToBeDisplayed(_whatAreMyFutureProspectsLink);
            _formCompletionHelper.ClickElement(_whatAreMyFutureProspectsLink);

            string actualWhatAreMyFutureProspectsHeader = _pageInteractionHelper.GetText(_whatAreMyFutureProspectsHeader);
            string actualWhatAreMyFutureProspectsParagraph1 = _pageInteractionHelper.GetText(_whatAreMyFutureProspectsParagraph1);
            string actualWhatAreMyFutureProspectsParagraph2 = _pageInteractionHelper.GetText(_whatAreMyFutureProspectsParagraph2);

            for (int i = 1; i <= 7; i++)
            {
                actualWhatAreMyFutureProspectsParagraph2BPList.Add(_pageInteractionHelper.GetText(By.XPath("//div[@class='page']/ul[1]/li[" + i + "]")));
            }

            _pageInteractionHelper.VerifyText(actualWhatAreMyFutureProspectsHeader, ExpectedWhatAreMyFutureProspectsHeader);
            _pageInteractionHelper.VerifyText(actualWhatAreMyFutureProspectsParagraph1, ExpectedWhatAreMyFutureProspectsParagraph1);
            _pageInteractionHelper.VerifyText(actualWhatAreMyFutureProspectsParagraph2, ExpectedWhatAreMyFutureProspectsParagraph2);
            _pageInteractionCampaignsHelper.compareContentOfTwoArraylists(actualWhatAreMyFutureProspectsParagraph2BPList, expectedWhatAreMyFutureProspectsParagraph2BPList);
        }

        internal void verifyContentUnderHowMuchCanYouEarnSection()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_howMuchCanYouEarnLink);
            _pageInteractionHelper.FocusTheElement(_howMuchCanYouEarnLink);

            string actualHowMuchCanYouEarnHeader = _pageInteractionHelper.GetText(_howMuchCanYouEarnHeader);
            string actualHowMuchCanYouEarnParagraph1 = _pageInteractionHelper.GetText(_howMuchCanYouEarnParagraph1);
            string actualHowMuchCanYouEarnParagraph2 = _pageInteractionHelper.GetText(_howMuchCanYouEarnParagraph2);
            string actualHowMuchCanYouEarnParagraph3 = _pageInteractionHelper.GetText(_howMuchCanYouEarnParagraph3);

            _pageInteractionHelper.VerifyText(actualHowMuchCanYouEarnHeader, ExpectedHowMuchCanYouEarnHeader);
            _pageInteractionHelper.VerifyText(actualHowMuchCanYouEarnParagraph1, ExpectedHowMuchCanYouEarnParagraph1);
            _pageInteractionHelper.VerifyText(actualHowMuchCanYouEarnParagraph2, ExpectedHowMuchCanYouEarnParagraph2);
            _pageInteractionHelper.VerifyText(actualHowMuchCanYouEarnParagraph3, ExpectedHowMuchCanYouEarnParagraph3);
        }

        internal void verifyContentUnderWhatWillMyApprenticeshipCostMeSection()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_whatWillMyApprenticeshipCostMeLink);
            _pageInteractionHelper.FocusTheElement(_whatWillMyApprenticeshipCostMeLink);
            _formCompletionHelper.ClickElement(_whatWillMyApprenticeshipCostMeLink);

            string actualWhatWillMyApprenticeshipCostMeHeader = _pageInteractionHelper.GetText(_whatWillMyApprenticeshipCostMeHeader);
            string actualWhatWillMyApprenticeshipCostMeParagraph1 = _pageInteractionHelper.GetText(_whatWillMyApprenticeshipCostMeParagraph1);
            string actualWhatWillMyApprenticeshipCostMeParagraph2 = _pageInteractionHelper.GetText(_whatWillMyApprenticeshipCostMeParagraph2);

            _pageInteractionHelper.VerifyText(actualWhatWillMyApprenticeshipCostMeHeader, ExpectedWhatWillMyApprenticeshipCostMeHeader);
            _pageInteractionHelper.VerifyText(actualWhatWillMyApprenticeshipCostMeParagraph1, ExpectedWhatWillMyApprenticeshipCostMeParagraph1);
            _pageInteractionHelper.VerifyText(actualWhatWillMyApprenticeshipCostMeParagraph2, ExpectedWhatWillMyApprenticeshipCostMeParagraph2);
         }

    }
}
