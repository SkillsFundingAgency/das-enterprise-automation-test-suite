using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ExtraInformationAboutPayPage : Raav2BasePage
    {
        protected override string PageTitle => "Extra information about pay";

        private static By ExtraPayInformation => By.CssSelector("#WageAdditionalInformation");


        public ExtraInformationAboutPayPage(ScenarioContext context) : base(context) { }

        public SubmitNoOfPositionsPage SubmitExtraInformationAboutPay()
        {
            formCompletionHelper.EnterText(ExtraPayInformation, rAAV2DataHelper.OptionalMessage);

            Continue();

            return new SubmitNoOfPositionsPage(context);
        }
    }
}
