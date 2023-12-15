using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Do you know which apprenticeship training your apprentice will take?";

        protected override bool TakeFullScreenShot => false;

        private static By YesRadioButton => By.CssSelector("label[for=ApprenticeTrainingKnown]");
        private static By TrainingCourseContainer => By.Id("SelectedCourseId");

        private static By StandardCourseOption => By.Id("SelectedCourseId__option--0");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickYesRadioButton()
        {
            formCompletionHelper.ClickElement(YesRadioButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage EnterSelectForACourseAndSubmit()
        {
            formCompletionHelper.EnterText(TrainingCourseContainer, apprenticeCourseDataHelper.CourseDetails.Course.title);
            formCompletionHelper.ClickElement(StandardCourseOption);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(context);
        }

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickSaveAndContinueButton()
        {
            Continue();
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(context);
        }
    }
}