using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetails2Page : ApprovalsBasePage
    {
        protected override string PageTitle => "Add apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddToAnExistingCohortRadio => By.Id("confirm-ExistingCohort");
        private By CreateANewCohort => By.Id("confirm-NewCohort");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderAddApprenticeDetails2Page(ScenarioContext context) : base(context) => _context = context;

        public void SelectOptionAddToAnExistingCohort()
        {
            formCompletionHelper.ClickElement(AddToAnExistingCohortRadio);
            Continue();
        }

        public ProviderChooseAnEmployerNonLevyPage SelectOptionCreateNewCohort()
        {
            javaScriptHelper.ClickElement(CreateANewCohort);
            Continue();
            return new ProviderChooseAnEmployerNonLevyPage(_context);
        }
    }
}