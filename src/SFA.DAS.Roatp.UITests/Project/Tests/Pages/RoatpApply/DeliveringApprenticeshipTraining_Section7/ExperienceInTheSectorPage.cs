using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class ExperienceInTheSectorPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "experience in the";

        public ExperienceInTheSectorPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatTypeOfTrainingDeliveredPage EnterExperienceDetails()
        {
            SelectRadioOptionByText("No experience");

            var options = pageInteractionHelper.FindElements(RadioLabels).Where(x => x.Text.Contains("No"));

            foreach (var item in options)
            {
                formCompletionHelper.ClickElement(item);
            }
            Continue();
            return new WhatTypeOfTrainingDeliveredPage(context);
        }

    }
}