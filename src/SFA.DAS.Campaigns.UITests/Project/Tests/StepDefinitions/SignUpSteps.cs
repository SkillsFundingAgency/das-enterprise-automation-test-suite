using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SignUpSteps(ScenarioContext context)
    {
        private readonly CampaignsStepsHelper _stepsHelper = new(context);

        private SignUpPage _signUpPage;

        [Given(@"the employer navigates to Sign Up Page")]
        public void GivenTheEmployerNavigatesToSignUpPage() => _signUpPage = _stepsHelper.GoToEmployerHubPage().NavigateToSignUpPage();

        [When(@"the employer fill Your details section")]
        public void WhenTheEmployerFillYourDetailsSection() => _signUpPage.YourDetails();

        [When(@"Your Company by selecting radiobutton Less than Ten employees")]
        public void WhenYourCompanyBySelectingRadiobuttonLessThanTenEmployees() => _signUpPage.SelectCompanySizeOption1();

        [When(@"Your Company by selecting radiobutton Between Ten and FourtyNine employees")]
        public void WhenYourCompanyBySelectingRadiobuttonBetweenTenAndFourtyNineEmployees() => _signUpPage.SelectCompanySizeOption2();

        [When(@"Your Company by selecting radiobutton Between Fifty and TwoFourtyNine employees")]
        public void WhenYourCompanyBySelectingRadiobuttonBetweenFiftyAndTwoFourtyNineEmployees() => _signUpPage.SelectCompanySizeOption3();

        [When(@"Your Company by selecting radiobutton Over TwoHundredandFifty employees")]
        public void WhenYourCompanyBySelectingRadiobuttonOverTwoHundredandFiftyEmployees() => _signUpPage.SelectCompanySizeOption4();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => _signUpPage.RegisterInterest();
    }
}
