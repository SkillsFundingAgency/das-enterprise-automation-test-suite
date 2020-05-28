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
    public class FAA_YourFeedbackPage : FAABasePage
    {
        protected override string PageTitle => "Your feedback";

        private By FeedbackText => By.CssSelector(".sfa-inset-yellow");
        private By SignOutLink => By.Id("signout-link");

        public FAA_YourFeedbackPage(ScenarioContext context) : base(context) { }

        public void VerifyReadFeedbackText()
        {
            _pageInteractionHelper.VerifyText(FeedbackText, _faadataHelper.OptionalMessage);
            _formCompletionHelper.Click(SignOutLink);
        }
    }
}
