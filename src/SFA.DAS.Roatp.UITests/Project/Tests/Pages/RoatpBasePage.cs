using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : BasePage
    {
        protected override By PageHeader => By.TagName("h1");

        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly ApplyUkprnDataHelpers applyUkprnDataHelpers;
        protected readonly ApplyDataHelpers applydataHelpers;
        protected readonly RoatpConfig roatpConfig;
        #endregion
        
        private By ChooseFile => By.ClassName("govuk-file-upload");

        public RoatpBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            applyUkprnDataHelpers = context.Get<ApplyUkprnDataHelpers>();
            applydataHelpers = context.Get<ApplyDataHelpers>();
            roatpConfig = context.GetRoatpConfig<RoatpConfig>();
        }

        protected void UploadFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + "Project\\Helpers\\UploadFiles\\" + "Sample.pdf";
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
        }
    }
}
