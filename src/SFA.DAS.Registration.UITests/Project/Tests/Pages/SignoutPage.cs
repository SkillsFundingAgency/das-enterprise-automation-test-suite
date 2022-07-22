using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignoutPage : VerifyBasePage
    {
        protected override string PageTitle => "You've logged out";

        public SignoutPage(ScenarioContext context) : base(context) => VerifyPage();


    }
}
