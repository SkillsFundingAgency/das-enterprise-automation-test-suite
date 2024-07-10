using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageMultiApplicationsUnsuccessfulPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Make multiple applications unsuccessful";
        private static By SaveContinue => By.CssSelector("#applicationsToUnsuccessful-action");
        private static By AllApplicantCheckbox => By.CssSelector(".govuk-checkboxes__input");
        private void OutcomeMultiSelectSharedWithEmployer()
        {
            formCompletionHelper.SelectCheckbox(AllApplicantCheckbox);
            formCompletionHelper.Click(SaveContinue);
        }
        public ProviderGiveFeedbackToMutlipleApplicants ProviderMakeAllSelectedApplicantsUnsucessful()
        {
            OutcomeMultiSelectSharedWithEmployer();
            return new ProviderGiveFeedbackToMutlipleApplicants(context);
        }
    }
}
