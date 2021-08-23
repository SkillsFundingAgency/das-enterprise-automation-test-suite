using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages
{
    public class UnauthorisedUserWithLoginPage : UnauthorisedAccessBasePage
    {
        protected override string PageTitle => "s2";

        protected override List<string> ExpectedPageTitles => new List<string> { SignInPageTitle, PageNotFoundPageTitle, AccessDeniedPageTitle };

        public UnauthorisedUserWithLoginPage(ScenarioContext context) : base(context) { }
    }
}
