using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class StubSignIn(ScenarioContext context) : AppBasePage(context)
    {
        protected override string PageTitle => "StubSignIn";
    }
}
