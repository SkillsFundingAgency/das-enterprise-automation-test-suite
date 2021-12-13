using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm the training provider";

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public ConfirmTrainingProviderPage(ScenarioContext context) : base(context) { }

        public SubmitNoOfPositionsPage ConfirmTrainingProviderAndContinue()
        {
            Continue();
            return new SubmitNoOfPositionsPage(_context);
        }
    }
}
