using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderRolesSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

        [Given(@"the user can view Draft, Pending, Rejected, Live and Closed vacancies")]
        public void GivenTheUserCanViewDraftPendingRejectedLiveAndClosedVacancies() => _providerStepsHelper.ViewVacancies();

        [Then(@"the user can view previewable (Draft|Rejected) vacancies via edit and submit link")]
        public void ThenTheUserCanViewVacanciesViaEditAndSubmitLink(string vacancyState) => _providerStepsHelper.ViewVacancyViaEditAndSubmitLink(vacancyState, true, false);

        [Then(@"the user cannot view non-previewable Draft vacancies via edit and submit link")]
        public void ThenTheUserCannotViewNon_PreviewableDraftVacanciesViaEditAndSubmitLink() => _providerStepsHelper.ViewVacancyViaEditAndSubmitLink("Draft", false, true);

        [Then(@"the user can view non-previewable Draft vacancies via edit and submit link")]
        public void ThenTheUserCanViewNon_PreviewableDraftVacanciesViaEditAndSubmitLink() => _providerStepsHelper.ViewVacancyViaEditAndSubmitLink("Draft", false, false);

        [Then(@"the user can view (PendingReview|Live|Closed) vacancies via manage link")]
        public void ThenTheUserCanViewVacanciesViaManageLink(string vacancyState) => _providerStepsHelper.ViewVacancyViaManageLink(vacancyState);

        [Then(@"the user can view applications to a (Live|Closed) vacancy on manage vacancy page")]
        public void ThenTheUserCanViewApplicationsToAVacancyOnManageVacancyPage(string vacancyState) => _providerStepsHelper.ViewApplicationsViaManageLink(vacancyState);

        [Then(@"the user can create reports")]
        public void ThenTheUserCanCreateReports() => _providerStepsHelper.CreateAReport();

        [Then(@"the user can manage thier recruitment emails")]
        public void ThenTheUserCanManageThierRecruitmentEmails() => _providerStepsHelper.ManageRecruitmentEmails();

        [Then(@"the user cannot create a new vacancy")]
        public void GivenTheUserCannotCreateANewVacancy() => _providerStepsHelper.CreateANewVacancyGoesToPermissionDenied(true);

        [Then(@"the user can create a new vacancy")]
        public void GivenTheUserCanCreateANewVacancy() => _providerStepsHelper.CreateANewVacancyGoesToPermissionDenied(false);

        [Then(@"the user cannot edit a (Draft|Rejected) vacancy via edit and submit link")]
        public void ThenTheUserCannotEditAVacancyViaEditAndSubmitLink(string vacancyState) => _providerStepsHelper.EditVacancyViaEditAndSubmitLink(vacancyState, true);

        [Then(@"the user can edit a (Draft|Rejected) vacancy via edit and submit link")]
        public void ThenTheUserCanEditAVacancyViaEditAndSubmitLink(string vacancyState) => _providerStepsHelper.EditVacancyViaEditAndSubmitLink(vacancyState, false);

        [Then(@"the user cannot \(re\)submit a (Draft|Rejected) vacancy")]
        public void ThenTheUserCannotReSubmitAVacancy(string vacancyState) => _providerStepsHelper.SubmitOrResubmitViaEditAndSubmitLink(vacancyState, true);

        [Then(@"the user can \(re\)submit a (Draft|Rejected) vacancy")]
        public void ThenTheUserCanReSubmitAVacancy(string vacancyState) => _providerStepsHelper.SubmitOrResubmitViaEditAndSubmitLink(vacancyState, false);

        [Then(@"the user cannot delete a (Draft|Rejected) vacancy")]
        public void ThenTheUserCannotDeleteAVacancy(string vacancyState) => _providerStepsHelper.DeleteVacancy(vacancyState, true);

        [Then(@"the user can delete a (Draft|Rejected) vacancy")]
        public void ThenTheUserCanDeleteAVacancy(string vacancyState) => _providerStepsHelper.DeleteVacancy(vacancyState, false);

        [Then(@"the user cannot clone a (PendingReview|Live|Closed) vacancy")]
        public void ThenTheUserCannotCloneAPendingReviewVacancy(string vacancyState) => _providerStepsHelper.CloneVacancy(vacancyState, true);

        [Then(@"the user can clone a (PendingReview|Live|Closed) vacancy")]
        public void ThenTheUserCanCloneAPendingReviewVacancy(string vacancyState) => _providerStepsHelper.CloneVacancy(vacancyState, false);

        [Then(@"the user cannot edit a Live vacancy via manage link")]
        public void ThenTheUserCannotEditALiveVacancyViaManageLink() => _providerStepsHelper.EditVacancyViaManageLink("Live", true);

        [Then(@"the user can edit a Live vacancy via manage link")]
        public void ThenTheUserCanEditALiveVacancyViaManageLink() => _providerStepsHelper.EditVacancyViaManageLink("Live", false);

        [Then(@"the user cannot close a Live vacancy")]
        public void ThenTheUserCannotCloseALiveVacancy() => _providerStepsHelper.CloseVacancy("Live", true);

        [Then(@"the user can close a Live vacancy")]
        public void ThenTheUserCanCloseALiveVacancy() => _providerStepsHelper.CloseVacancy("Live", false);

        [Then(@"the user cannot save successful or unsuccessful applications for a Live vacancy")]
        public void ThenTheUserCannotSaveSuccessfulOrUnsuccessfulApplicationsForALiveVacancy()
        {
            _providerStepsHelper.UpdateApplicationStatusViaManageLink("Live", true, true);
            _providerStepsHelper.UpdateApplicationStatusViaManageLink("Live", false, true);
        }

        [Then(@"the user can save successful or unsuccessful applications for a Live vacancy")]
        public void ThenTheUserCanSaveSuccessfulOrUnsuccessfulApplicationsForALiveVacancy()
        {
            _providerStepsHelper.UpdateApplicationStatusViaManageLink("Live", true, false);
            _providerStepsHelper.UpdateApplicationStatusViaManageLink("Live", false, false);
        }
    }
}
