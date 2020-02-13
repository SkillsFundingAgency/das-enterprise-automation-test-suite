using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_YourFeedbackPage : BasePage
    {
        protected override string PageTitle => "Your feedback";

        private By FeedbackText => By.CssSelector(".sfa-inset-yellow");
        private By SignOutLink => By.Id("signout-link");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RAAV1DataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public FAA_YourFeedbackPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void VerifyReadFeedbackText()
        {
            _pageInteractionHelper.VerifyText(FeedbackText, _dataHelper.OptionalMessage);
            _formCompletionHelper.Click(SignOutLink);
        }
    }
}
