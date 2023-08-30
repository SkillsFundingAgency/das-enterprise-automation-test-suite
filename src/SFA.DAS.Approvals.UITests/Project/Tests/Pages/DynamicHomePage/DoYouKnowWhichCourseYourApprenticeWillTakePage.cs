using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DoYouKnowWhichCourseYourApprenticeWillTakePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Do you know which course your apprentice will take?";

        private static By ClickYesContinue => By.Id("which-course-your-apprentice-will-take-button");

        public DoYouKnowWhichCourseYourApprenticeWillTakePage (ScenarioContext context) : base(context)  { }

        public HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage YesToCourse()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            formCompletionHelper.Click(ClickYesContinue);
            return new HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage(context);
       }
    }
}
