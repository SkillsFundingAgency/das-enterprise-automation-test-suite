using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ApprenticeshipServiceDevHubPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Using Apprenticeship service APIs";

        protected override bool TakeFullScreenShot => false;

        private readonly By DisplayAdvertApiLink = By.LinkText("Display advert API");
        private readonly By RecruitmentApiLink = By.LinkText("Recruitment API");
        private readonly By DevHubSignInLink = By.LinkText("sign in to get an API key");
      
        public DisplayAdvertAPIPage ClickDisplayAdvertApiLink()
        {
            formCompletionHelper.ClickElement(DisplayAdvertApiLink);
            return new DisplayAdvertAPIPage(context);
            
        }

        public RecruitmentAPIPage ClickRecruitmentApiLink()
        {
            formCompletionHelper.Click(RecruitmentApiLink);
            return new RecruitmentAPIPage(context);
        }

        public DevHubSignInPage ClickDevHubSignInLink()
        {
            formCompletionHelper.Click(DevHubSignInLink);
            return new DevHubSignInPage(context);
        }
    }
}
