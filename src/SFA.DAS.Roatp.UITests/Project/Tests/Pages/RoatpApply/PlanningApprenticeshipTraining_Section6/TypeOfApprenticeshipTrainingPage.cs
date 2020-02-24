using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class TypeOfApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What type of apprenticeship training will your organisation offer?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StandardsCheckBox => By.Id("option_0");

        private By FrameworksCheckBox => By.Id("option_1");

        private By partFrameWorksCheckBox => By.Id("option_3");

        public TypeOfApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReadyToDeliverTrainingPage SelectStandardsFrameworksAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(StandardsCheckBox));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FrameworksCheckBox));
            Continue();
            return new ReadyToDeliverTrainingPage(_context);
        }

        public OfferingApprenticeshipFrameworksPage SelectFrameworksOnlyAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FrameworksCheckBox));
            Continue();
            return new OfferingApprenticeshipFrameworksPage(_context);
        }
    }
}
