using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages
{
    public class UnauthorisedUserWithoutLoginPage(ScenarioContext context, string url) : UnauthorisedAccessBasePage(context, url)
    {
        protected override string PageTitle => "S1";

        protected override List<string> ExpectedPageTitles => new() { SignInPageTitle, PageNotFoundPageTitle };
    }
}
