using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages
{
    public class UnauthorisedUserWithoutLoginPage : UnauthorisedAccessBasePage
    {
        protected override string PageTitle => "s1";

        protected override List<string> ExpectedPageTitles => new List<string> { SignInPageTitle, PageNotFoundPageTitle };

        public UnauthorisedUserWithoutLoginPage(ScenarioContext context) : base(context) { }
    }
}
