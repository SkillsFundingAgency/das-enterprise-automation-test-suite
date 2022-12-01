using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
        protected override string PageTitle => "Edit training details";

        protected override By AddButtonSelector => By.XPath("//button[text()='Save']");

        public EditTrainingDetailsPage(ScenarioContext context) : base(context)
        {
        }   

    }
}