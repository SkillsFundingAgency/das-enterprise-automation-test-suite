using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
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
            _formCompletionHelper.EnterText(Title, $"{_dataHelper.VacancyTitle}");
            _formCompletionHelper.Click(Continue);
            _objectContext.SetVacancyTitle(_dataHelper.VacancyTitle);
            return new ApprenticeshipTrainingPage(_context);
        }
    }
}
