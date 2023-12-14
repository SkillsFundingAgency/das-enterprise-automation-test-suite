using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public abstract class AreYouSurePage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected void SelectYesAndContinue()
        {
            SelectRadioOptionByForAttribute("Yes");
            Continue();
        }
    }
}