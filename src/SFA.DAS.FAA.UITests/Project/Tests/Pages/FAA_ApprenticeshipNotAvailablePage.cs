using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeshipNotAvailablePage : BasePage
    {
        protected override string PageTitle => "Apprenticeship no longer available";

        public FAA_ApprenticeshipNotAvailablePage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
