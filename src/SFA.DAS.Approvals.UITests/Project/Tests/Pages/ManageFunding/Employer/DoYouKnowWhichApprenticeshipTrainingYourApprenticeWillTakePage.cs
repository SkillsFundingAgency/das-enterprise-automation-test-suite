using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DoYouKnowWhichTrainingCourseYourLearnerWillTakePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Do you know which training course your learner will take?";

        protected override bool TakeFullScreenShot => false;

        private static By YesRadioButton => By.CssSelector("label[for=ApprenticeTrainingKnown]");
        private static By TrainingCourseContainer => By.Id("SelectedCourseId");

        private static By StandardCourseOption => By.Id("SelectedCourseId__option--0");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public DoYouKnowWhichTrainingCourseYourLearnerWillTakePage ClickYesRadioButton()
        {
            formCompletionHelper.ClickElement(YesRadioButton);
            return new DoYouKnowWhichTrainingCourseYourLearnerWillTakePage(context);
        }

        public DoYouKnowWhichTrainingCourseYourLearnerWillTakePage EnterSelectForACourseAndSubmit()
        {
            formCompletionHelper.EnterText(TrainingCourseContainer, apprenticeCourseDataHelper.CourseDetails.Course.title);
            formCompletionHelper.ClickElement(StandardCourseOption);
            return new DoYouKnowWhichTrainingCourseYourLearnerWillTakePage(context);
        }

        public WhenWillTheTrainingStartPage ClickSaveAndContinueButton()
        {
            Continue();
            return new WhenWillTheTrainingStartPage(context);
        }
    }
}