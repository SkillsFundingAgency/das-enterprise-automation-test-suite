using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_CandidateApplicationPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Applications";

        private By SignOut => By.Id("signout-link");        

        public RAA_CandidateApplicationPage(ScenarioContext context) : base(context)
        {
            
        }

        public void ExitFromRAA()
        {
            formCompletionHelper.Click(SignOut);
        }
    }
}
