using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public abstract class RoatpGateWayBasePage : RoatpBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _frameworkConfig;
        #endregion

        protected By EnterCommentsForFail => By.Id("OptionFailText");

        public RoatpGateWayBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _frameworkConfig = context.Get<FrameworkConfig>();
        }

        protected void SelectPassAndContinue()
        {
            SelectRadioOptionByText("Pass");
            Continue();
        }

        protected void SelectFailAndContinue(string text)
        {
            SelectRadioOptionByText("Fail");
            formCompletionHelper.EnterText(EnterCommentsForFail, text);
            Continue();
        }

        protected void SelectInProgressAndContinue()
        {
            SelectRadioOptionByText("InProgress");
            Continue();
        }

    }
}
