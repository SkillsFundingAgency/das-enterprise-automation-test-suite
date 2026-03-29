using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class CreateANewReportPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Create a report";
        private readonly By GenerateReportButton = By.XPath("//button[normalize-space(.)='Generate report']");
        private readonly By BackToDashboardbutton = By.LinkText("Back to report dashboard");


        public ReportsDashboardPage SelectTimePeriodAndContinue()
        {
            SelectRadioOptionByForAttribute("daterange-7");
            formCompletionHelper.Click(GenerateReportButton);
            pageInteractionHelper.WaitForElementToBeClickable(BackToDashboardbutton);
            formCompletionHelper.Click(BackToDashboardbutton);
            return new ReportsDashboardPage(context);
        }

    }
}