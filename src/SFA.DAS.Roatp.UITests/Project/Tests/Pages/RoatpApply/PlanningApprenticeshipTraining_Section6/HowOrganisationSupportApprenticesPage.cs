using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class HowOrganisationSupportApprenticesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation support its apprentices?";

        private By ThroughAMentorCheckBox => By.Id("option_0");
        private By OtherCheckbox => By.Id("option_4");

        public HowOrganisationSupportApprenticesPage(ScenarioContext context) : base(context) => VerifyPage();

        public OtherWaysToSupportApprenticesPage SelectThroughAMentorAndOTherAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ThroughAMentorCheckBox));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OtherCheckbox));
            Continue();
            return new OtherWaysToSupportApprenticesPage(context);
        }
    }
}


