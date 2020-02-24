using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TrusteesDOBPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the date of birth for trustees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TrusteesDOBPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}


