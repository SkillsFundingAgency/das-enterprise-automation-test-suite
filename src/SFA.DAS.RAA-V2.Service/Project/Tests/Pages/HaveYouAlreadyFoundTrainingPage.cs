using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class HaveYouAlreadyFoundTrainingPage : Raav2BasePage
    {
        protected override string PageTitle => "Have you already found apprenticeship training?";

        private By YesRadioButton => By.Id("has_training_yes");

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public HaveYouAlreadyFoundTrainingPage(ScenarioContext context) : base(context) { }

        public ApprenticeshipTrainingPage SelectYes()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);

            Continue();

            return new ApprenticeshipTrainingPage(context);
        }
    }
}
