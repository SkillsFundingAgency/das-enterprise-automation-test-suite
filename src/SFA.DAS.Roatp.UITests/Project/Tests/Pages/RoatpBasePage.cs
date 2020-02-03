using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : BasePage
    {
        protected override By PageHeader => By.TagName("h1");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly ApplyUkprnDataHelpers applyUkprnDataHelpers;
        protected readonly ApplyDataHelpers applydataHelpers;
        protected readonly RoatpConfig roatpConfig;
        private readonly FrameworkConfig _frameworkConfig;
        #endregion

        private By ChooseFile => By.ClassName("govuk-file-upload");

        private By Dob => By.CssSelector("#dob");

        private By Month => By.CssSelector("input[id*='Month']");

        private By Year => By.CssSelector("input[id*='Year']");

        public RoatpBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            applyUkprnDataHelpers = context.Get<ApplyUkprnDataHelpers>();
            applydataHelpers = context.Get<ApplyDataHelpers>();
            roatpConfig = context.GetRoatpConfig<RoatpConfig>();
            _frameworkConfig = context.Get<FrameworkConfig>();
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
