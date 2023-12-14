using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ChooseTrainingProviderPage : Raav2BasePage
    {
        protected override string PageTitle => "Have you found a training provider?";

        private static By TrainingProviderSearch => By.CssSelector("#TrainingProviderSearch");

        private static By FirstOption => By.CssSelector("#TrainingProviderSearch__option--0");

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public ChooseTrainingProviderPage(ScenarioContext context) : base(context) { }

        public ConfirmTrainingProviderPage ChooseFoundATrainingProvider()
        {
            SelectRadioOptionByForAttribute("found_yes");

            return SelectTrainingProvider();
        }

        public ConfirmTrainingProviderPage SelectTrainingProvider()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, RAAV2DataHelper.Provider); return pageInteractionHelper.FindElement(FirstOption); });

            Continue();

            return new ConfirmTrainingProviderPage(context);
        }
    }
}