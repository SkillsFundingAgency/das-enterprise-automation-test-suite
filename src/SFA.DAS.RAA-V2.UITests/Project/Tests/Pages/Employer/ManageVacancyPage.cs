using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{

    public class ManageVacancyPage : BasePage
    {
        protected override string PageTitle => "Manage vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By Applicant => By.CssSelector(".responsive a");

        public ManageVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ViewVacancyPage NavigateToViewVacancyPage()
        {
            _formCompletionHelper.ClickLinkByText("View vacancy");
            return new ViewVacancyPage(_context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            _formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(_context);
        }
    }
}
