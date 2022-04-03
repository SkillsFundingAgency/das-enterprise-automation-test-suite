using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class SelectStandardPage : AddApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select standard";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public SelectStandardPage(ScenarioContext context) : base(context) { }

        public ProviderAddApprenticeDetailsPage SelectAStandard()
        {
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, apprenticeCourseDataHelper.Course);
            Continue();
            return new ProviderAddApprenticeDetailsPage(context);
        }
    }
}
