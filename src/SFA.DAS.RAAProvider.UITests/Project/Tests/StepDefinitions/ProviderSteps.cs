using SFA.DAS.RAAProvider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps(ScenarioContext context)
    {
        private readonly ProviderStepsHelper _providerStepsHelper = new(context);

        [Then(@"Provider can make the application in review")]
        public void ThenProviderCanMakeTheApplicationInReview() => _providerStepsHelper.ApplicantReview();

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();

        [Then(@"Provider can see the withdrawn application")]
        public void ThenProviderCanSeeTheWithdrawnApplication() => _providerStepsHelper.ApplicantWithdrawn();

        [Then(@"Provider can share multiple applications")]
        public void ThenProviderCanShareMultipleApplications() => _providerStepsHelper.ShareMutipleApplicants();

        [Then(@"Provider can make the application shared")]
        public void ThenProviderCanMakeTheApplicationShared() => _providerStepsHelper.ApplicantShared();

        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();

        [Then(@"Provider can make multiple applications unsuccessful")]
        public void ThenProviderCanMakeMultipleApplicationsUnsuccessful() => _providerStepsHelper.MutipleApplicantsUnsucessful();

        [Then(@"Provider can make the application interviewing with Employer")]
        public void ThenProviderCanMakeTheApplicationInterviewingWithEmployer() => _providerStepsHelper.InterviewWithEmployer();

        [Then(@"the Provider verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type|Set As Competitive)' the wage option selected in the Preview page")]
        public void ThenTheProviderVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _providerStepsHelper.VerifyWageType(wageType);

        [Then(@"Provider can view the refered vacancy")]
        public void ThenProviderCanViewTheReferedVacancy() => _providerStepsHelper.ViewReferVacancy();

        [Then(@"the Provider can close the vacancy")]
        public void ThenTheProviderCanCloseTheVacancy() => _providerStepsHelper.CloseVacancy();

        [Then(@"the Provider can edit the vacancy")]
        public void ThenTheProviderCanEditTheVacancy() => _providerStepsHelper.EditVacancyDates();
    }
}
