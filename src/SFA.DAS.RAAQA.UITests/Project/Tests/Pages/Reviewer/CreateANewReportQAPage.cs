using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public class CreateANewReportQAPage(ScenarioContext context) : RAAQABasePage(context)
    {
        protected override string PageTitle => "Choose the time period for the report";
        private readonly By GenerateReportButton = By.XPath("//button[normalize-space(.)='Generate report']");
        private readonly By BackToDashboardbutton = By.LinkText("Back to report dashboard");


        public ReportsDashboardQAPage ChooseTimePeriodAndContinue()
        {
            SelectRadioOptionByForAttribute("daterange-7");
            formCompletionHelper.Click(GenerateReportButton);
            pageInteractionHelper.WaitForElementToBeClickable(BackToDashboardbutton);
            formCompletionHelper.Click(BackToDashboardbutton);
            return new ReportsDashboardQAPage(context);
        }

    }
}