using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ChooseTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Have you found a training provider?";

        private By TrainingProviderSearch => By.CssSelector("#TrainingProviderSearch");

        private By FirstOption => By.CssSelector("#TrainingProviderSearch__option--0");

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public ChooseTrainingProviderPage(ScenarioContext context) : base(context) { }

        public ConfirmTrainingProviderPage ChooseFoundATrainingProvider()
        {
            SelectRadioOptionByForAttribute("found_yes");

            return SelectTrainingProvider();
        }

        public ConfirmTrainingProviderPage SelectTrainingProvider()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, rAAV2DataHelper.Provider); return pageInteractionHelper.FindElement(FirstOption); });

            Continue();

            return new ConfirmTrainingProviderPage(context);
        }
    }
}