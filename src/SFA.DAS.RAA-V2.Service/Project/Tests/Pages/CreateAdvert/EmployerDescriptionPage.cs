using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class EmployerDescriptionPage : Raav2BasePage
    {
        protected override string PageTitle => $"Information about {objectContext.GetEmployerName()}";

        private By EmployerDescription => By.CssSelector("#EmployerDescription");

        private By EmployerWebsiteUrl => By.CssSelector("#EmployerWebsiteUrl");

        private By IsDisabilityConfident => By.CssSelector("#IsDisabilityConfident");

        public EmployerDescriptionPage(ScenarioContext context) : base(context) { }
        
        public PreviewYourAdvertOrVacancyPage EnterEmployerDescription()
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
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
