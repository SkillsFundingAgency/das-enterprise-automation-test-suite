using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class DescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Description of the apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By iframeBody = By.CssSelector(".mce-content-body ");
        private By OutcomeDescription = By.Id("OutcomeDescription_ifr");
        private By TrainingDescription = By.Id("TrainingDescription_ifr");
        private By VacancyDescription = By.Id("VacancyDescription_ifr");

        public DescriptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyPreviewPart2Page EnterDescription()
        {
            _pageInteractionHelper.SwitchFrame(VacancyDescription, iframeBody, dataHelper.VacancyShortDescription);
            _pageInteractionHelper.SwitchFrame(TrainingDescription, iframeBody, dataHelper.TrainingDetails);
            _pageInteractionHelper.SwitchFrame(OutcomeDescription, iframeBody, dataHelper.VacancyOutcome);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
