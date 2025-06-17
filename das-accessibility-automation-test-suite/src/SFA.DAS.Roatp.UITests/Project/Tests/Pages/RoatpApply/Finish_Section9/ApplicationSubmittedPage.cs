using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class ApplicationSubmittedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application complete";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        public ApplicationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationSubmittedPage SetApplicationReference()
        {
            objectContext.SetApplicationReference(RegexHelper.GetApplicationReference(pageInteractionHelper.GetText(PageHeader)));

            return this;
        }
    }
}
