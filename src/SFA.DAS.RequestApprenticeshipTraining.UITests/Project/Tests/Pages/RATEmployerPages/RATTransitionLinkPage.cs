using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class RATTransitionLinkPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "";

        #region Locators
        private static By AskIfTrainingProvidersCanRunThisCourseLink => By.LinkText("Ask if training providers can run this course");
        #endregion

        public void TransitionToRATFromFAT()
        {
            formCompletionHelper.Click(AskIfTrainingProvidersCanRunThisCourseLink); 
        }
    }
}