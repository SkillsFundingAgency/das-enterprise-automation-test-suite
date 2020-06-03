using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyTitlePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What do you want to call this vacancy?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By Title => By.CssSelector("#Title");
        
        public VacancyTitlePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            ChangeVacancyTitle();
            return new ApprenticeshipTrainingPage(_context);
        }

        public HaveYouAlreadyFoundTrainingPage EnterVacancyTitleForTheFirstVacancy()
        {
            ChangeVacancyTitle();
            return new HaveYouAlreadyFoundTrainingPage(_context);
        }

        public VacancyPreviewPart2Page UpdateVacancyTitle()
        {
            ChangeVacancyTitle();
            return new VacancyPreviewPart2Page(_context);
        }

        private void ChangeVacancyTitle()
        {
            formCompletionHelper.EnterText(Title, $"{rAAV2DataHelper.VacancyTitle}");
            Continue();
            _objectContext.SetVacancyTitle(rAAV2DataHelper.VacancyTitle);
        }
    }
}
