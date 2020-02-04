using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ApplicationSubmittedPage : RoatpBasePage
    {
        protected override string PageTitle => "Application submitted";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private readonly RegexHelper _regexHelper;
        #endregion

        public ApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _regexHelper = context.Get<RegexHelper>();
            VerifyPage();
        }

        public ApplicationSubmittedPage SetApplicationReference()
        {
            var value = pageInteractionHelper.GetText(PageHeader);
            var reference = _regexHelper.GetApplicationReference(value);
            _objectContext.SetApplicationReference(reference);
            return this;
        }
    }
}
