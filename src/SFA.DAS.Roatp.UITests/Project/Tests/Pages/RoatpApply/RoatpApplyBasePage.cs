using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public abstract class RoatpApplyBasePage : RoatpBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _frameworkConfig;
        protected readonly RoatpApplyDataHelpers applydataHelpers;
        protected readonly RoatpApplyUkprnDataHelpers roatpUkprnDataHelpers;
        #endregion

        private By ChooseFile => By.ClassName("govuk-file-upload");

        private By Dob => By.CssSelector("#dob");

        private By Month => By.CssSelector("input[id*='Month']");

        private By Year => By.CssSelector("input[id*='Year']");

        protected virtual By LongTextArea => By.CssSelector(".govuk-fieldset .govuk-textarea");

        public RoatpApplyBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _frameworkConfig = context.Get<FrameworkConfig>();
            applydataHelpers = context.Get<RoatpApplyDataHelpers>();
            roatpUkprnDataHelpers = context.Get<RoatpApplyUkprnDataHelpers>();
        }

        protected void UploadFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
        }

        protected void SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
        }

        protected void SelectNoAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
        }

        protected void EnterLongTextAreaAndContinue(string text)
        {
            formCompletionHelper.EnterText(LongTextArea, text);
            Continue();
        }

        public ApplicationOverviewPage ReturnToApplicationOverview()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOverviewPage(_context);
        }

        public ApplicationOverviewPage EnterDateOfBirth()
        {
            var dobs = pageInteractionHelper.FindElements(Dob).ToList();

            int count = 0;

            foreach (var dob in dobs)
            {
                var dobcalc = applydataHelpers.Dob(count++);
                var month = dob.FindElement(Month);
                formCompletionHelper.EnterText(month, dobcalc.Month);

                var year = dob.FindElement(Year);
                formCompletionHelper.EnterText(year, dobcalc.Year);
            }

            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
