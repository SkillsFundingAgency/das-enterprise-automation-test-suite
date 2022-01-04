using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIApplicationOpenOn11JanPage : EIBasePage
    {
        protected override string PageTitle => "Applications open on 11 January 2022";

        #region Locators
        
        #endregion

        public EIApplicationOpenOn11JanPage(ScenarioContext context) : base(context)  { }

        public HomePage ReturnToAccountHomePage()
        {
            formCompletionHelper.ClickLinkByText("Return to account home");
            return new HomePage(context);
        }
    }
}
