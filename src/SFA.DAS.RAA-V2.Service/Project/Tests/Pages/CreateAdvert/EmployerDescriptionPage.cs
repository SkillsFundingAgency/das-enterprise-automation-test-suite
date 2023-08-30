using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class EmployerDescriptionPage : Raav2BasePage
    {
        protected override string PageTitle => $"Information about {objectContext.GetEmployerName()}";

        private static By EmployerDescription => By.CssSelector("#EmployerDescription");

        private static By EmployerWebsiteUrl => By.CssSelector("#EmployerWebsiteUrl");

        private static By IsDisabilityConfident => By.CssSelector("#IsDisabilityConfident");

        public EmployerDescriptionPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage EnterEmployerDescription()
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public ContactDetailsPage EnterEmployerDescriptionAndGoToContactDetailsPage(bool optionalFields)
        {
            EnterDetails(optionalFields);
            return new ContactDetailsPage(context);
        }

        public CheckYourAnswersPage EnterEmployerDescriptionAndGoToCheckYourAnswersPage(bool optionalFields)
        {
            EnterDetails(optionalFields);
            return new CheckYourAnswersPage(context);
        }

        private void EnterDetails(bool optionalFields)
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            if (optionalFields)
            {
                formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
                if (!isRaaV2Employer)
                    formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(IsDisabilityConfident));
            }

            Continue();
        }
        public ContactDetailsPage EnterEmployerDescriptionAndGoToContactDetailsPage(bool disabilityConfidence, bool optionalFields)
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            if (optionalFields)
            {
                formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
                if (!isRaaV2Employer) formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(IsDisabilityConfident));
            }
            else
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(IsDisabilityConfident));
            }
            Continue();
            return new ContactDetailsPage(context);
        }
    }
}
