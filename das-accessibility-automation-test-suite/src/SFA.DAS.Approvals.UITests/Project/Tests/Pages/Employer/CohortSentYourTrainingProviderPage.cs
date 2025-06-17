using DnsClient;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortSentYourTrainingProviderPage(ScenarioContext context) : CohortReferenceBasePage(context)
    {
        protected override string PageTitle => "Add apprentice request sent to training provider";
        protected override bool TakeFullScreenShot => false;
        private static By MessageForTrainingProvider => By.CssSelector(".govuk-summary-list__row:nth-child(3) > .govuk-summary-list__value");

        public CohortSentYourTrainingProviderPage VerifyMessageForTrainingProvider(string expectedText)
        {
            string actualText = pageInteractionHelper.GetText(MessageForTrainingProvider);
            Assert.That(actualText, Is.EqualTo(expectedText.Trim()));
            return this;
        }
    }
}