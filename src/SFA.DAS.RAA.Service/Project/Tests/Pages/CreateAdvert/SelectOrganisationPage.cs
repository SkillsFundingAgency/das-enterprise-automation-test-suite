using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class SelectOrganisationPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => isRaaV2Employer ? "Which organisation is this advert for?" : "What training course will the apprentice take?";

        public WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(context);
        }

        public ApprenticeshipTrainingPage SelectOrganisationMultiOrg()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new ApprenticeshipTrainingPage(context);
        }
    }
}
