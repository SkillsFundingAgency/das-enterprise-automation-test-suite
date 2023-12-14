using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class SelectOrganisationPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => isRaaV2Employer ? "Which organisation is this advert for?" : "Which organisation do you want to create a vacancy for?";

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

        public TraineeshipSectorPage SelectOrganisationMultiOrgTraineeship()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new TraineeshipSectorPage(context);
        }
    }
}
