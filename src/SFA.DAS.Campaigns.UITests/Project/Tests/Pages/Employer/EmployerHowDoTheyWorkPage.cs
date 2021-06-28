using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHowDoTheyWorkPage : EmployerBasePage
    {
        protected override string PageTitle => "How do they work?";

        public EmployerHowDoTheyWorkPage(ScenarioContext context) : base(context) { }

        public void VerifyHowDoTheyWorkPageSubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Hiring an apprentice");
            VerifyPage(func, "Upskilling your current staff");
            VerifyPage(func, "Funding an apprenticeship");
            VerifyPage(func, "Training your apprentice");
            VerifyPage(func, "End-point assessments");
            VerifyPage(func, "Financial incentives for employers");
        }
    }
}