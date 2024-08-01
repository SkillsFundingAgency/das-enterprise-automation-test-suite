using OpenQA.Selenium;
using Polly;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class AskIfTrainingProvidersCanRunThisCoursePage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Ask if training providers can run this course";

        #region Locators
        private static By ClickStartNowButton => By.CssSelector(".govuk-button govuk-button--start");
        #endregion

        public AskIfTrainingProvidersCanRunThisCoursePage ClickStatNow()
        {
            formCompletionHelper.Click(ClickStartNowButton);
            return new AskIfTrainingProvidersCanRunThisCoursePage(context);
        }
    }       
}