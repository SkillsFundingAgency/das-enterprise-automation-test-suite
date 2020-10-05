using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EndPointAssessmentPage : EmployerBasePage
    {
        protected override string PageTitle => "End-point assessment";

        private By FiuCardHeading => By.CssSelector(".fiu-article h2");
        
        public EndPointAssessmentPage(ScenarioContext context) : base(context) { }

        public void VerifyEndPointAssessmentPageSubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Finding an end-point assessment organisation");
            VerifyPage(func, "What does assessment involve?");
            VerifyPage(func, "Certification");
        }
    }
}