using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps(ScenarioContext context)
    {
        private RecruitmentDynamicHomePage _dynamicHomePage;

        [Given(@"the Employer logs into Employer account")]
        public void GivenTheEmployerLogsIntoEmployerAccount() => new EmployerHomePageStepsHelper(context).GotoEmployerHomePage();

        [Given(@"the employer reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage() => new ManageFundingEmployerStepsHelper(context).CreateReservationViaDynamicHomePageTriageJourney();

        [Then(@"the vacancy details is displayed on the Dynamic home page with Status '(DRAFT|CLOSED|PENDING REVIEW|LIVE|REJECTED)'")]
        public void GivenTheVacancyDetailsIsDisplayedOnTheDynamicHomePageWithStatus(string status)
        {
            switch (status)
            {
                case "DRAFT":
                case "REJECTED":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(context, true).ConfirmVacancyTitleAndStatus(status);
                    break;

                case "CLOSED":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(context, true).ConfirmClosedVacancyDetails(status);
                    break;

                case "PENDING REVIEW":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(context, true).ConfirmVacancyDetails(status, context.Get<RAAV2DataHelper>().VacancyClosing);
                    break;

                case "LIVE":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(context, true).ConfirmLiveVacancyDetails(status);
                    break;
            }
        }

        [Then(@"Employer can go to vacancy dashboard")]
        public void ThenEmployerCanGoToVacancyDashboard() => _dynamicHomePage.GoToVacancyDashboard();

        [Then(@"Employer can go to Manage vacancy page")]
        public void ThenEmployerCanGoToManageVacancyPage() => _dynamicHomePage.GoToManageVacancyPage();

        [Then(@"Employer can continue creating an advert")]
        public void ThenEmployerCanContinueCreatingAnAdvert() => _dynamicHomePage.ContinueCreatingYourAdvert();

        [Then(@"the Employer can review and resubmit the vacancy")]
        public void ThenTheEmployerCanReviewAndResubmitTheVacancy() => _dynamicHomePage.ReviewYourVacancy().ResubmitVacancy();
    }
}