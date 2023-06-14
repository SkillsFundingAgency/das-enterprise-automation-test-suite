using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Do you know which apprenticeship training your apprentice will take?";

        protected override bool TakeFullScreenShot => false;

        private By YesRadioButton => By.CssSelector("label[for=ApprenticeTrainingKnown]");
        private By TrainingCourseContainer => By.Id("SelectedCourseId");

        private By StandardCourseOption => By.Id("SelectedCourseId__option--0");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(ScenarioContext context) : base(context)  { }

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