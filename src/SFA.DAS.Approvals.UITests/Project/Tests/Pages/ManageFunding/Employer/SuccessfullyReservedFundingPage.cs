using System;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SuccessfullyReservedFundingPage : BasePage
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
        private By SuccessMessage => By.CssSelector("govuk-panel--confirmation");
        private By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");
        private By ContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public SuccessfullyReservedFundingPage(ScenarioContext context) : base(context)
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

        private void ChooseToAddApprenticeRadioButton()
        {
            _formCompletionHelper.ClickElement(AddApprenticeRadioButton);
        }

        private void ClickContinueButton()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }

        internal AddAnApprenitcePage AddApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            ClickContinueButton();
            return new AddAnApprenitcePage(_context);
        }

        internal AddApprenticeDetailsPage AddAnotherApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            ClickContinueButton();
            return new AddApprenticeDetailsPage(_context);
        }
    }
}
