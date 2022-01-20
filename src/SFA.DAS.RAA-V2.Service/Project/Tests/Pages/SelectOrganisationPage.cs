using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class SelectOrganisationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Which organisation is this advert for?" : "Which organisation is this vacancy for?";

        public SelectOrganisationPage(ScenarioContext context) : base(context) { }

        public WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(context);
        }
    }
}
