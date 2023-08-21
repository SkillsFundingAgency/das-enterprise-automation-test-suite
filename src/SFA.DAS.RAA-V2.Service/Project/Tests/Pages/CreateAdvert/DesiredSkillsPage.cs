using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class DesiredSkillsPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "What skills and personal qualities would you like applicants to have?" : "What skills and personal qualities do applicants need to have?";

        private static By Skills => By.CssSelector("label.govuk-checkboxes__label");

        protected override By ContinueButton => By.CssSelector(".save-button[data-automation='btn-continue']");

        public DesiredSkillsPage(ScenarioContext context) : base(context) { }

        public QualificationsPage SelectSkillAndGoToQualificationsPage()
        {
            SelectSkillsAndContinue();

            return new QualificationsPage(context);
        }

        public FutureProspectsPage SelectSkillsAndGoToFutureProspectsPage()
        {
            SelectSkillsAndContinue();

            return new FutureProspectsPage(context);
        }

        private void SelectSkillsAndContinue()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Skills)));

            Continue();

        }
    }
}
