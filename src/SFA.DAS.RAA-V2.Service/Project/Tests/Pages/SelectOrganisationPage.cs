using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class SelectOrganisationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Which organisation is this advert for?" : "Which organisation is this vacancy for?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        public SelectOrganisationPage(ScenarioContext context) : base(context) => _context = context;

        public WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(_context);
        }
    }
}
