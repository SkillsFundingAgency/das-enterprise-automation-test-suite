using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TrusteesDOBPage : RoatpBasePage
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


