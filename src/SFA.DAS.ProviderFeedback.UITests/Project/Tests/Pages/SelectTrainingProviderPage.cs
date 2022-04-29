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

        private By SelectLink => By.XPath("//*[@id='main-content']/table/tbody/tr/td[4]/a");

        public SelectTrainingProviderPage(ScenarioContext context) : base(context) { }

        public ConfirmProviderPage SelectTrainingProvider()
        {
            formCompletionHelper.ClickElement(SelectLink);
            return new ConfirmProviderPage(context);
        }

    }
}
