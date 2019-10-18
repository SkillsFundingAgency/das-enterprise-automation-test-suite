using System;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class MakingChangesPage : ReservationIdBasePage
    {
        protected override string PageTitle => "Making changes";
        private By SuccessMessage => By.CssSelector("govuk-panel--confirmation");
        private By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");
        private By ContinueButton => By.CssSelector(".govuk-button");
        private By GoToRadioButton => By.CssSelector(".govuk-radios__label");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public MakingChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal HomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToRadioButton, "WhatsNext-home");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new HomePage(_context);
        }

        public bool IsReserveFundingSuccessMessageUpdated()
        {
            if (pageInteractionHelper.IsElementDisplayed(SuccessMessage))
            {
                SetCurrentReservationId();
                return true;
            }
            else
            {
                throw new Exception("Reserve Funding is not successfully created");
            }       
        }

        internal AddAnApprenitcePage AddApprentice()
        {
            _formCompletionHelper.ClickElement(AddApprenticeRadioButton);
            _formCompletionHelper.ClickElement(ContinueButton);
            return new AddAnApprenitcePage(_context);
        }
    }
}
