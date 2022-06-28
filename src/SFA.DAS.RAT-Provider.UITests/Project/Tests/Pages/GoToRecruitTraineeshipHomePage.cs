using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class GoToRecruitTraineeshipHomePage : ProviderHomePage
    {
        public GoToRecruitTraineeshipHomePage(ScenarioContext context) : base(context, true) { }

        public RecruitmentHomePage NavigateToRecruitTrainee()
        {
            formCompletionHelper.ClickElement(RecruitTrainees);

            ClickIfPirenIsDisplayed();

            return new RecruitmentHomePage(context);
        }
    }
}
