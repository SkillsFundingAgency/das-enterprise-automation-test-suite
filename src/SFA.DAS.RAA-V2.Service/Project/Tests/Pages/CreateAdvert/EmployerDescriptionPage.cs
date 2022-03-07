using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class EmployerDescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => $"Information about {objectContext.GetEmployerName()}";

        private By EmployerDescription => By.CssSelector("#EmployerDescription");

        private By EmployerWebsiteUrl => By.CssSelector("#EmployerWebsiteUrl");

        public EmployerDescriptionPage(ScenarioContext context) : base(context) { }
        
        public VacancyPreviewPart2Page EnterEmployerDescription()
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            Continue();
            return new VacancyPreviewPart2Page(context);
        }

        public ContactDetailsPage EnterEmployerDescriptionAndGoToContactDetailsPage()
        {
            formCompletionHelper.EnterText(EmployerDescription, rAAV2DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerWebsiteUrl, rAAV2DataHelper.EmployerWebsiteUrl);
            Continue();
            return new ContactDetailsPage(context);
        }
    }
}
