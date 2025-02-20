using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public abstract class AppBasePage : VerifyBasePage
    {
        public AppBasePage(ScenarioContext context) : base(context)
        {

        }
    }
}
