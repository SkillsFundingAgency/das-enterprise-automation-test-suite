using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class SelectTrainingOptionsPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Select training options";

        #region Locators
        private static By ClickAtApprenticesWorkplace => By.XPath("(//div[@class='govuk-checkboxes__item'])[1]");
        private static By ClickDayRelease => By.XPath("(//div[@class='govuk-checkboxes__item'])[2]");
        private static By ClickBlockRelease => By.XPath("(//div[@class='govuk-checkboxes__item'])[3]");
        #endregion

        public SelectTrainingOptionsPage ClickCheckboxes()
        {
            formCompletionHelper.Click(ClickAtApprenticesWorkplace);
            formCompletionHelper.Click(ClickDayRelease);
            formCompletionHelper.Click(ClickDayRelease);
            Continue();
            return new SelectTrainingOptionsPage(context);
        }
    }
}
