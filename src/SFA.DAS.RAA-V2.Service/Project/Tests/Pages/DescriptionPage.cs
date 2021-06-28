using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Description of the apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By IframeBody => By.CssSelector(".mce-content-body ");
        private By OutcomeDescription => By.Id("OutcomeDescription_ifr");
        private By TrainingDescription => By.Id("TrainingDescription_ifr");
        private By VacancyDescription => By.Id("VacancyDescription_ifr");

        public DescriptionPage(ScenarioContext context) : base(context) => _context = context;

        public VacancyPreviewPart2Page EnterDescription()
        {
            javaScriptHelper.SwitchFrameAndEnterText(VacancyDescription, IframeBody, rAAV2DataHelper.VacancyShortDescription);
            javaScriptHelper.SwitchFrameAndEnterText(TrainingDescription, IframeBody, rAAV2DataHelper.TrainingDetails);
            javaScriptHelper.SwitchFrameAndEnterText(OutcomeDescription, IframeBody, rAAV2DataHelper.VacancyOutcome);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
