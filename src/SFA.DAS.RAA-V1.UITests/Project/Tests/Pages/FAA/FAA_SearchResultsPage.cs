using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_SearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        public FAA_SearchResultsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
