using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class WhatTeachingMethodsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What teaching methods will your organisation use to deliver 20% off the job training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LearningSupportAndWrittenAssignmentsChekbox => By.Id("option_2");

        public WhatTeachingMethodsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OfftheJobTrainingIsRelevantPage SelectLearningSupportAndWrritenAssignmentsAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(LearningSupportAndWrittenAssignmentsChekbox));
            Continue();
            return new OfftheJobTrainingIsRelevantPage(_context);
        }
    }
}
