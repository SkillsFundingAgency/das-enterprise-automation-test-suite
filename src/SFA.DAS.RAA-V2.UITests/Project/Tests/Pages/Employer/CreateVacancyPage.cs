using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class CreateVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Create vacancy";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public CreateVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void SelectAVacancy()
        {
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            _formCompletionHelper.Click(Continue);
        }

        public VacancyTitlePage CreateNewVacancy()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "create-new");
            _formCompletionHelper.Click(Continue);
            return new VacancyTitlePage(_context);
        }
    }
}
