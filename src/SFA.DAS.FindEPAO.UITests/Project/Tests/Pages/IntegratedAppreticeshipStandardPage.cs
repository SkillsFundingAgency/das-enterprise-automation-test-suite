using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class IntegratedAppreticeshipStandardPage(ScenarioContext context) : FindEPAOBasePage(context)
    {
        protected override string PageTitle => "The training provider will carry out the end-point assessment";

        private static By BackToSearchApprenticeshipTraining => By.ClassName("govuk-back-link");

        public SearchApprenticeshipTrainingCoursePage NavigateBackFromIntegratedApprenticeshipsPage()
        {
            NavigateBackToSearchApprenticeshipTraining();
            return new SearchApprenticeshipTrainingCoursePage(context);
        }
        public SearchApprenticeshipTrainingCoursePage NavigateBackToSearchApprenticeshipTraining()
        {
            formCompletionHelper.Click(BackToSearchApprenticeshipTraining);
            return new SearchApprenticeshipTrainingCoursePage(context);
        }
    }
}
