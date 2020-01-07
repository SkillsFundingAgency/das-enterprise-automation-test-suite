using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class SelectOrganisationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which organisation is this vacancy for?";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion
        
        public SelectOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public EmployerNamePage SelectOrganisation()
        {
            formCompletionHelper.ClickElement(() => dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new EmployerNamePage(_context);
        }
    }
}
