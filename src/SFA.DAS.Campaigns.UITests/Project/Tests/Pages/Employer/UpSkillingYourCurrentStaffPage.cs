using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class UpSkillingYourCurrentStaffPage : EmployerBasePage
    {
        protected override string PageTitle => "Upskilling your workforce";

        public UpSkillingYourCurrentStaffPage(ScenarioContext context) : base(context)
        {
            //pageInteractionHelper.VerifyPage(PageHeader, PageTitle);
        }
    }
}