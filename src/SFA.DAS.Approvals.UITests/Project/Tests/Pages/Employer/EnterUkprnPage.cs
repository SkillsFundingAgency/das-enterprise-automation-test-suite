using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterUkprnPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.TagName("h1");
        protected override string PageTitle => "Enter the new training provider's name or reference number (UKPRN)";
        protected override By ContinueButton => By.Id("Ukprn-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ChangeOfPartyConfig _changeOfPartyConfig;
        #endregion


        private By TrainingProviderSearch => By.CssSelector("#Ukprn");
        private By FirstOption => By.CssSelector("#Ukprn__option--0");


        public EnterUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
        }

        public ConfirmRequestForChangeOfProviderPage ChooseTrainingProviderPage()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, _changeOfPartyConfig.Ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new ConfirmRequestForChangeOfProviderPage(_context);
        }
    }
}
