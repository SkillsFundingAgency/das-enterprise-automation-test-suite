using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class ExperienceInTheSectorPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "experience in the";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NoOption => By.CssSelector(".govuk-radios__label");

        public ExperienceInTheSectorPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhatTypeOfTrainingDeliveredPage EnterExperienceDetails()
        {
            SelectRadioOptionByText("No experience");

            var options = pageInteractionHelper.FindElements(NoOption).Where(x => x.Text.Contains("No"));

            foreach (var item in options)
            {
                formCompletionHelper.ClickElement(item);
            }
            Continue();
            return new WhatTypeOfTrainingDeliveredPage(_context);
        }

    }
}