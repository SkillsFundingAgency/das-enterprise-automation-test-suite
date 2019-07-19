using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class WizardPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"welcome\"]/h1")]
        private IWebElement _title;
        [FindsBy(How = How.XPath, Using = "//*[@id=\"welcome\"]/p")]
        private IWebElement _description;
        private const string closebtncss = "#welcome a.close";
        [FindsBy(How = How.CssSelector, Using = closebtncss)]
        private IWebElement _closeButton;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item:nth-child(1)")]
        private IWebElement _step1;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item.complete:nth-child(1) a")]
        private IWebElement _step1ReviewButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-paye-1\"]")]
        private IWebElement _step1YesRadioButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-paye-2\"]")]
        private IWebElement _step1NoRadioButton;
        [FindsBy(How = How.CssSelector, Using = "#add-paye-schemes-guide a")]
        private IWebElement _step1AddPayeSchemesButton;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item:nth-child(2)")]
        private IWebElement _step2;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item.complete:nth-child(2) a")]
        private IWebElement _step2ReviewButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-organisations-1\"]")]
        private IWebElement _step2YesRadioButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-organisations-2\"]")]
        private IWebElement _step2NoRadioButton;
        [FindsBy(How = How.CssSelector, Using = "#guide-wizard-step-organisations a")]
        private IWebElement _step2AddOrganisationsButton;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item:nth-child(3)")]
        private IWebElement _step3;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item.complete:nth-child(3) a")]
        private IWebElement _step3ReviewButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-members-1\"]")]
        private IWebElement _step3YesRadioButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-members-2\"]")]
        private IWebElement _step3NoRadioButton;
        [FindsBy(How = How.CssSelector, Using = "#guide-wizard-step-members a")]
        private IWebElement _step3AddMembersButton;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item:nth-child(4)")]
        private IWebElement _step4;
        [FindsBy(How = How.CssSelector, Using = "#welcome .todo-list--item.complete:nth-child(4) a")]
        private IWebElement _step4ReviewButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-agreements-1\"]")]
        private IWebElement _step4YesRadioButton;
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"add-agreements-2\"]")]
        private IWebElement _step4NoRadioButton;
        [FindsBy(How = How.CssSelector, Using = "#guide-wizard-step-agreements a")]
        private IWebElement _step4ViewAgreementsButton;
        [FindsBy(How = How.CssSelector, Using = "#confirmation a")]
        private IWebElement _completeButton;
        public WizardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return
                _title.WaitForElementToBeVisibleExtension() &&
                _description.WaitForElementToBeVisibleExtension() &&
                _step1.WaitForElementToBeVisibleExtension() &&
                _title.Text.EndsWith("welcome to your new digital account") &&
                _description.Text == "Follow these steps to set up your account.";
        }

        internal Homepage.Homepage Close()
        {
            _formCompletionHelper.ClickAndWaitForInvisibilityOfAnElement(_closeButton, By.CssSelector(closebtncss));
            return new Homepage.Homepage(WebBrowserDriver);
        }

        internal WizardPage SelectStep(int stepNumber, bool answer)
        {
            var element = this.GetStepRadioButton(stepNumber, answer);
            this._formCompletionHelper.SelectRadioButton(element);
            return this;
        }

        internal WizardPage ClickStepReview(int stepNumber)
        {
            var element = this.GetStepReviewButton(stepNumber);
            element.WaitForElementToBeVisibleExtension();
            element.Click();
            return this;
        }

        internal bool CheckStepIsVisible(int stepNumber)
        {
            return
                this.GetStep(stepNumber).Displayed &&
                this.GetStepRadioButton(stepNumber, true).Displayed &&
                this.GetStepRadioButton(stepNumber, false).Displayed;
        }

        internal bool CheckStepIsComplete(int stepNumber)
        {
            return
                this.GetStep(stepNumber).HasClassExtension("complete");
        }

        internal WizardPage OpenStep1AddPayeSchemesPage()
        {
            this._step1AddPayeSchemesButton.WaitForElementToBeVisibleExtension();
            this._step1AddPayeSchemesButton.Click();
            return this;
        }

        internal WizardPage OpenStep2AddOrganisationsPage()
        {
            this._step2AddOrganisationsButton.WaitForElementToBeVisibleExtension();
            this._step2AddOrganisationsButton.Click();
            return this;
        }

        internal WizardPage OpenStep3AddMembersPage()
        {
            this._step3AddMembersButton.WaitForElementToBeVisibleExtension();
            this._step3AddMembersButton.Click();
            return this;
        }

        internal WizardPage OpenStep4AddMembersPage()
        {
            this._step4ViewAgreementsButton.WaitForElementToBeVisibleExtension();
            this._step4ViewAgreementsButton.Click();
            return this;
        }

        internal WizardPage OpenStep4SignAgreementsPage()
        {
            this._step4ViewAgreementsButton.WaitForElementToBeVisibleExtension();
            this._step4ViewAgreementsButton.Click();
            return this;
        }

        internal Homepage.Homepage Complete()
        {
            _completeButton.WaitForElementToBeVisibleExtension();
            _completeButton.Click();
            return new Homepage.Homepage(WebBrowserDriver);
        }

        private IWebElement GetStep(int stepNumber)
        {
            switch (stepNumber)
            {
                case 1: return _step1;
                case 2: return _step2;
                case 3: return _step3;
                case 4: return _step4;
                default: throw new Exception("Invalid step number");
            }
        }

        private IWebElement GetStepReviewButton(int stepNumber)
        {
            switch (stepNumber)
            {
                case 1: return _step1ReviewButton;
                case 2: return _step2ReviewButton;
                case 3: return _step3ReviewButton;
                case 4: return _step4ReviewButton;
                default: throw new Exception("Invalid step number");
            }
        }

        private IWebElement GetStepRadioButton(int stepNumber, bool answer)
        {
            switch (stepNumber)
            {
                case 1: return answer ? this._step1YesRadioButton : this._step1NoRadioButton;
                case 2: return answer ? this._step2YesRadioButton : this._step2NoRadioButton;
                case 3: return answer ? this._step3YesRadioButton : this._step3NoRadioButton;
                case 4: return answer ? this._step4YesRadioButton : this._step4NoRadioButton;
                default: throw new Exception("Invalid step number");
            }
        }
    }
}