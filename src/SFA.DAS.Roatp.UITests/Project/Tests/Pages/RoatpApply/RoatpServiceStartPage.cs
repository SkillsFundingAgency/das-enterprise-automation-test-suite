using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class RoatpServiceStartPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Apply to join the register of apprenticeship training providers (RoATP)";

        private static By ApplyNow => By.LinkText("Apply now");

        public RoatpServiceStartPage(ScenarioContext context) : base(context) => VerifyPage();

        public UsedThisServiceBeforePage ClickApplyNow()
        {
            formCompletionHelper.ClickElement(ApplyNow);
            return new UsedThisServiceBeforePage(context);
        }
    }
}
