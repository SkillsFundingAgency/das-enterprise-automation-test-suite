using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public abstract class AreYouSurePage : ModeratorBasePage
    {
        public AreYouSurePage(ScenarioContext context) : base(context) { }

        protected void SelectYesAndContinue()
        {
            SelectRadioOptionByForAttribute("Yes");
            Continue();
        }
    }
}