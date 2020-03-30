using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderSelectEmployerPage : BasePage
    {
        public ProviderSelectEmployerPage(ScenarioContext context) : base(context)
        {
        }

        protected override string PageTitle { get; }
    }
}
