using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ExtraInformationAboutPayPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Extra information about pay";

        private static By ExtraPayInformation => By.CssSelector("#WageAdditionalInformation");

        public SubmitNoOfPositionsPage SubmitExtraInformationAboutPay()
        {
            formCompletionHelper.EnterText(ExtraPayInformation, rAADataHelper.OptionalMessage);

            Continue();

            return new SubmitNoOfPositionsPage(context);
        }
    }
}
