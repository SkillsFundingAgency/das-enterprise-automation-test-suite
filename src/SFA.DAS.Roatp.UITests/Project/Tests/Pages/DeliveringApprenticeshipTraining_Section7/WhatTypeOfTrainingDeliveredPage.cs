using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class WhatTypeOfTrainingDeliveredPage : RoatpBasePage
    {
        protected override string PageTitle => "What type of apprenticeship training have they delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-3");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatTypeOfTrainingDeliveredPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowHaveTheyDeliveredTrainingToApprenticesPage SelectTypeOfApprenticeship()
        {
            SelectRadioOptionByText("Apprenticeship frameworks");
            Continue();
            return new HowHaveTheyDeliveredTrainingToApprenticesPage(_context);
        }

    }
}