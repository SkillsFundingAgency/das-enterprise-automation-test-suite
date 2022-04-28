using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ApplicationProcessPage : Raav2BasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        private By Yes => By.CssSelector("#application-method-faa");

        private By ApplicationUrl => By.CssSelector("#ApplicationUrl");

        private By ApplicationInstructions => By.CssSelector("#ApplicationInstructions");

        public ApplicationProcessPage(ScenarioContext context) : base(context) { }

        public CreateAnApprenticeshipAdvertOrVacancyPage SelectApplicationMethod_Employer(bool isFAA) { SelectApplicationMethod(isFAA); return new CreateAnApprenticeshipAdvertOrVacancyPage(context); }

        public CheckYourAnswersPage SelectApplicationMethod_Provider(bool isFAA) { SelectApplicationMethod(isFAA); return new CheckYourAnswersPage(context); }

        public PreviewYourAdvertOrVacancyPage ApplicationMethod(bool isFAA) { { if (isFAA) ApplicationMethodFAA(); else ApplicationMethodExternal(); } return SaveAndContinue(); }

        private void ApplicationMethodFAA() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(Yes));

        private void ApplicationMethodExternal()
        {
            SelectRadioOptionByForAttribute("application-method-external");
            formCompletionHelper.EnterText(ApplicationUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            formCompletionHelper.EnterText(ApplicationInstructions, rAAV2DataHelper.OptionalMessage);

        }
        private PreviewYourAdvertOrVacancyPage SaveAndContinue()
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
