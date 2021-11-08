using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class ApplicationSubmittedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application complete";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        #endregion

        public ApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public ApplicationSubmittedPage SetApplicationReference()
        {
            var value = pageInteractionHelper.GetText(PageHeader);
            var reference = RegexHelper.GetApplicationReference(value);
            _objectContext.SetApplicationReference(reference);
            return this;
        }
    }
}
