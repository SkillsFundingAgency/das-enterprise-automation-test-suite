using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ConfirmProviderPage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "Confirm training provider";

        private By ClickonContinue => By.XPath("//button[@class='govuk-button']");

        private By Yes => By.Id("correctprovider-yes");

        public ConfirmProviderPage(ScenarioContext context) : base(context) { }

        public ProvideFeedbackHomePage ConfirmTrainingProvider()
        {
            formCompletionHelper.SelectRadioOptionByLocator(Yes);
            formCompletionHelper.ClickElement(ClickonContinue);             
            return new ProvideFeedbackHomePage(context);
        }
    }
 }

