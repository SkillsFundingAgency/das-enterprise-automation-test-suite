using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsViaSelectJourneyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddToAnExistingCohortRadio => By.Id("confirm-ExistingCohort");
        private By CreateANewCohort => By.Id("confirm-NewCohort");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderAddApprenticeDetailsViaSelectJourneyPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderChooseACohortPage SelectOptionAddToAnExistingCohort()
        {
            javaScriptHelper.ClickElement(AddToAnExistingCohortRadio);
            Continue();
            return new ProviderChooseACohortPage(_context);
        }

        public ProviderChooseAnEmployerNonLevyPage SelectOptionCreateNewCohort()
        {
            javaScriptHelper.ClickElement(CreateANewCohort);
            Continue();
            return new ProviderChooseAnEmployerNonLevyPage(_context);
        }
    }
}