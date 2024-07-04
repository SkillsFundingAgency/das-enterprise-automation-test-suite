using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA.Service.Project.Tests.Pages.ProviderConfirmApplicantInterviewPage;
using static SFA.DAS.RAA.Service.Project.Tests.Pages.ProviderDoYouWantToShareAnApplicationBasePage;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageApplicantPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => rAAV2DataHelper.CandidateFullName;

        private static By SaveStatus => By.CssSelector("button[type='submit'][class='govuk-button']");

        private void OutcomeInterviewWithEmployer()
        {
            SelectRadioOptionByForAttribute("outcome-interviewing");
            SaveAndContinue();
        }
        public ProviderInteviewingApplicantPage MarkApplicantInterviewWithEmployer()
        {
            OutcomeInterviewWithEmployer(); 
            return new ProviderInteviewingApplicantPage(context);
        }
        private void OutcomeSharedWithEmployer()
        {
            SelectRadioOptionByForAttribute("outcome-shared");
            SaveAndContinue();
        }

        public ProviderDoYouWantToShareAnApplicationPage ProviderShareApplicantWithEmployer()
        {
            OutcomeSharedWithEmployer();
            return new ProviderDoYouWantToShareAnApplicationPage(context);
        }

        public ProviderAreYouSureSuccessfulPage ProviderShareApplicant()
        {
            Outcomesuccessful();
            return new ProviderAreYouSureSuccessfulPage(context);
        }

        public ConfirmApplicantSucessfulPage MakeApplicantSucessful()
        {
            Outcomesuccessful();
            return new ConfirmApplicantSucessfulPage(context);
        }

        public ConfirmApplicantUnsuccessfulPage MakeApplicantUnsucessful()
        {
            OutcomeUnsuccessful(() => formCompletionHelper.EnterText(CandidateFeedback, rAAV2DataHelper.OptionalMessage));
            return new ConfirmApplicantUnsuccessfulPage(context);
        }


        public ProviderAreYouSureSuccessfulPage ProviderMakeApplicantSucessful()
        {
            Outcomesuccessful();
            return new ProviderAreYouSureSuccessfulPage(context);
        }

        public ProviderGiveFeedbackPage ProviderMakeApplicantUnsucessful()
        {
            OutcomeUnsuccessful(null);
            return new ProviderGiveFeedbackPage(context);
        }

        private void Outcomesuccessful()
        {
            SelectRadioOptionByForAttribute("outcome-successful");
            SaveAndContinue();
        }


        private void OutcomeUnsuccessful(Action action)
        {
            SelectRadioOptionByForAttribute("outcome-unsuccessful");

            action?.Invoke();

            SaveAndContinue();
        }

        private new void SaveAndContinue() => formCompletionHelper.Click(SaveStatus);
    }
}
