using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ApplicationProcessPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        private By Yes => By.CssSelector("#application-method-faa");

        private By ApplicationUrl => By.CssSelector("#ApplicationUrl");

        private By ApplicationInstructions => By.CssSelector("#ApplicationInstructions");

        public ApplicationProcessPage(ScenarioContext context) : base(context) { }

        public CreateAnApprenticeshipAdvertOrVacancyPage SelectApplicationMethod_Employer(bool isFAA) { SelectApplicationMethod(isFAA); return new CreateAnApprenticeshipAdvertOrVacancyPage(context); }

        public CheckYourAnswersPage SelectApplicationMethod_Provider(bool isFAA) { SelectApplicationMethod(isFAA); return new CheckYourAnswersPage(context); }

        public PreviewYouAdvertOrVacancyPage ApplicationMethod(bool isFAA) { { if (isFAA) ApplicationMethodFAA(); else ApplicationMethodExternal(); } return SaveAndContinue(); }

        private void ApplicationMethodFAA() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(Yes));

        private void ApplicationMethodExternal()
        {
            SelectRadioOptionByForAttribute("application-method-external");
            formCompletionHelper.EnterText(ApplicationUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            formCompletionHelper.EnterText(ApplicationInstructions, rAAV2DataHelper.OptionalMessage);

        }
        private PreviewYouAdvertOrVacancyPage SaveAndContinue()
        {
            Continue();
            return new PreviewYouAdvertOrVacancyPage(context);
        }

        private void SelectApplicationMethod(bool isFAA)
        {
            if (isFAA) ApplicationMethodFAA(); else ApplicationMethodExternal();

            Continue();
        }
    }
}
