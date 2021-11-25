using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which employer do you want to create a vacancy for?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public SelectEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyTitlePage SelectEmployer(string empName)
        {
            if (string.IsNullOrEmpty(empName))
                _formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            else
                SelectRadioOptionByText(empName);

            Continue();
            return new VacancyTitlePage(_context);
        }
    }
}
