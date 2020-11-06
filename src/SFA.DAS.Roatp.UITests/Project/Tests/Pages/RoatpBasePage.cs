using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : BasePage
    {
        protected override By PageHeader => By.TagName("h1");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        protected By ChooseFileSelector => By.ClassName("govuk-file-upload");

        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RoatpConfig roatpConfig;
        private readonly FrameworkConfig _frameworkConfig;
        #endregion

        protected RoatpBasePage(ScenarioContext context) : base(context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            objectContext = context.Get<ObjectContext>();
            tableRowHelper = context.Get<TableRowHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            roatpConfig = context.GetRoatpConfig<RoatpConfig>();
        }

        protected void ChooseFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFileSelector, File);
            Continue();
        }
    }
}
