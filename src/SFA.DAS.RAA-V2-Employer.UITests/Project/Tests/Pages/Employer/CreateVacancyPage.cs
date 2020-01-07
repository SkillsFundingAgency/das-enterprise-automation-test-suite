using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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
        }

        public VacancyTitlePage CreateNewVacancy()
        {
            SelectRadioOptionByForAttribute("create-new");
            Continue();
            return new VacancyTitlePage(_context);
        }
    }
}
