using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ApplicationProcessPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "How would you like to receive applications?";

        private static By Yes => By.CssSelector("#application-method-faa");

        private static By ApplicationUrl => By.CssSelector("#ApplicationUrl");

        private static By ApplicationInstructions => By.CssSelector("#ApplicationInstructions");

        public CreateAnApprenticeshipAdvertOrVacancyPage SelectApplicationMethod_Employer(bool isFAA) { SelectApplicationMethod(isFAA); return new CreateAnApprenticeshipAdvertOrVacancyPage(context); }

        public CreateAnApprenticeshipAdvertOrVacancyPage SelectApplicationMethod_Provider(bool isFAA) { SelectApplicationMethod(isFAA); return new CreateAnApprenticeshipAdvertOrVacancyPage(context); }

        public PreviewYourAdvertOrVacancyPage ApplicationMethod(bool isFAA) { { if (isFAA) ApplicationMethodFAA(); else ApplicationMethodExternal(); } return SaveAndContinueToPreviewPage(); }

        private void ApplicationMethodFAA() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(Yes));

        private void ApplicationMethodExternal()
        {
            SelectRadioOptionByForAttribute("application-method-external");
            formCompletionHelper.EnterText(ApplicationUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            formCompletionHelper.EnterText(ApplicationInstructions, rAAV2DataHelper.OptionalMessage);

        }

        private PreviewYourAdvertOrVacancyPage SaveAndContinueToPreviewPage()
        {
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        private void SelectApplicationMethod(bool isFAA)
        {
            if (isFAA) ApplicationMethodFAA(); else ApplicationMethodExternal();

            Continue();
        }
    }
}
