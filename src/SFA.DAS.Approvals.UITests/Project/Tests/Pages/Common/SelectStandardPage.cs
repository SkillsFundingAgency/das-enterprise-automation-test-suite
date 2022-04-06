using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System.Linq;
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

        public ProviderEditApprenticeDetailsPage SelectAStandardForEditApprenticeDetailsPath()
        {
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, apprenticeCourseDataHelper.Course);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectableAndContinue()
        {
            var options = formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);
            Assert.False(options.All(x => x.Contains("(Framework)")));
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}
