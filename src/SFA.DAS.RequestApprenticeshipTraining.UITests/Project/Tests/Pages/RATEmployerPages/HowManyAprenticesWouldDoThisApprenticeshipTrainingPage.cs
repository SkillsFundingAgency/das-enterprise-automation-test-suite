using OpenQA.Selenium;
using Polly;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "How many apprentices would do this apprenticeship training?";

        #region Locators
        private static By EnterNumberOfApprentices => By.CssSelector(".govuk-input govuk-input--width-4");
        #endregion

        public HowManyAprenticesWouldDoThisApprenticeshipTrainingPage EnterHowManypprentices()
        {
            formCompletionHelper.EnterText(EnterNumberOfApprentices, 1);
            Continue();
            return new HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(context);
        }
    }
}