using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderSelectLearnerFromILRPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        private static By SelectLeanerLink => By.CssSelector("td[data-label='Select'] .govuk-link");

        protected override string PageTitle => "Select learner from ILR";

        internal ProviderAddApprenticeDetailsPage SelectFirstLearner()
        {
            formCompletionHelper.ClickElement(SelectLeanerLink);
            return new ProviderAddApprenticeDetailsPage(context);
        }

    }
}
