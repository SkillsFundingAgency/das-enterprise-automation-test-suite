using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeAreTheyRightForYouPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Are they right for you?";

        public ApprenticeAreTheyRightForYouPage(ScenarioContext context) : base(context) { }

        public ApprenticeAreTheyRightForYouPage VerifyApprenticeAreTheyRightForYouPageSubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Real stories");
            VerifyPage(func, "What are the benefits of an apprenticeship?");
            VerifyPage(func, "Help shape their career");
            VerifyPage(func, "Browse by interest");

            return this;
        }
    }
}