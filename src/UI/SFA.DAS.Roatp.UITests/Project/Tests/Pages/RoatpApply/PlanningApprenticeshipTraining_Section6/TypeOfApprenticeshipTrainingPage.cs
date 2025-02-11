using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class TypeOfApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What type of apprenticeship training will your organisation offer?";

        private static By StandardsCheckBox => By.Id("option_0");
        private static By FrameworksCheckBox => By.Id("option_1");
        private static By FunctionalSkills => By.Id("option_2");

        public TypeOfApprenticeshipTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ReadyToDeliverTrainingPage SelectStandardsFrameworksAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(StandardsCheckBox));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FrameworksCheckBox));
            Continue();
            return new ReadyToDeliverTrainingPage(context);
        }

        public OfferingApprenticeshipFrameworksPage SelectFrameworksOnlyAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FrameworksCheckBox));
            Continue();
            return new OfferingApprenticeshipFrameworksPage(context);
        }

        public ApplicationOverviewPage SelectFunctionalSkillsAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FunctionalSkills));
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
