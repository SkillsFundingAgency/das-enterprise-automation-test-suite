using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class VacancyTitlePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What do you want to call this vacancy?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper dataHelper;
        #endregion

        private By Title => By.CssSelector("#Title");

        public VacancyTitlePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            _formCompletionHelper.EnterText(Title, $"{dataHelper.VacancyTitle} apprenticeship");
            _formCompletionHelper.Click(Continue);
            return new ApprenticeshipTrainingPage(_context);
        }
    }
}
