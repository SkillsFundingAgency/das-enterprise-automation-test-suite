using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class SelectTrainingProviderPage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "Select a training provider";

        private By SelectLink => By.CssSelector("a[href*='/YGLK6W/providers/10000528']");

        public SelectTrainingProviderPage(ScenarioContext context) : base(context) { }

        public ConfirmProviderPage SelectTrainingProvider()
        {
            formCompletionHelper.ClickElement(SelectLink);
            return new ConfirmProviderPage(context);
        }

    }
}
