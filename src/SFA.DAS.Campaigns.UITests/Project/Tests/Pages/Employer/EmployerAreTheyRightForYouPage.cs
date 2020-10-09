using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerAreTheyRightForYouPage: EmployerBasePage
    {
        protected override string PageTitle => "Are they right for you?";

        public EmployerAreTheyRightForYouPage(ScenarioContext context): base(context) { }

        public void VerifyApprenticeHowDoTheyWorkPageSubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Real stories");
            VerifyPage(func, "Benefits to your organisation");
            VerifyPage(func, "Browse by sector");
        }
    }
}