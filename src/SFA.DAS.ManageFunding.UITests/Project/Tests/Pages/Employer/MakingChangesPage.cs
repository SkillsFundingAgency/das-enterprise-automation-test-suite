using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    public class MakingChangesPage : BasePage
    {
        protected override string PageTitle => "Making changes";
        private By SuccessMessage => By.CssSelector("govuk-panel--confirmation");
        private By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");
        private By ContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public MakingChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public bool IsReserveFundingSuccessMessageUpdated()
        {
            if (_pageInteractionHelper.IsElementDisplayed(SuccessMessage))
                throw new Exception("Reserve Funding is not successfully created");
            else
                return true;
        }

        internal void AddApprentice()
        {
            _formCompletionHelper.ClickElement(AddApprenticeRadioButton);
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}
