using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA.Service.Project.Tests.Pages.ProviderDoYouWantToShareAnApplicationBasePage;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageShareApplicationsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Share applications";
        private static By SaveContinue => By.CssSelector("#applications-to-share-action");
        private static By AllApplicantCheckbox => By.CssSelector(".govuk-checkboxes__input");
        private void OutcomeMultiSelectSharedWithEmployer()
        {
            formCompletionHelper.SelectCheckbox(AllApplicantCheckbox);
            formCompletionHelper.Click(SaveContinue);
        }
        public ProviderDoYouWantToShareAnApplicationPage ProviderShareApplicantWithEmployer()
        {
            OutcomeMultiSelectSharedWithEmployer();
            return new ProviderDoYouWantToShareAnApplicationPage(context);
        }

    }
}
