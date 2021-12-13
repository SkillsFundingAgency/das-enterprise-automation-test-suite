using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class WhatTypeOfTrainingDeliveredPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What type of apprenticeship training have they delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-3");

        public WhatTypeOfTrainingDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();

        public HowHaveTheyDeliveredTrainingToApprenticesPage SelectTypeOfApprenticeship()
        {
            SelectRadioOptionByText("Apprenticeship frameworks");
            Continue();
            return new HowHaveTheyDeliveredTrainingToApprenticesPage(context);
        }

    }
}