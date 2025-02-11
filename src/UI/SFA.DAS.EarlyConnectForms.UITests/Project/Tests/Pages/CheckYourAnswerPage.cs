using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages.ConfirmSurveySentPage;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class CheckYourAnswerPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your details before they’re sent to DfE";
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public ApplicantSurveySummitedPage AcceptAndSubmitForm()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApplicantSurveySummitedPage(context);
        }

    }
}
