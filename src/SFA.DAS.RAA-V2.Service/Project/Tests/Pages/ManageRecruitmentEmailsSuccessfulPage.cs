using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageRecruitmentEmailsSuccessfulPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "You’ve successfully saved your recruitment email preferences";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ManageRecruitmentEmailsSuccessfulPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
