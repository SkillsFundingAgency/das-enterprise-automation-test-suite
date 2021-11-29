using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your training provider";
        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourTrainingProviderPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetProviderName()),
                () => VerifyPage(ProviderHelpSectionLink),
                () => VerifyPage(ProviderHelpSectionText)
            });
        }
    }
}
