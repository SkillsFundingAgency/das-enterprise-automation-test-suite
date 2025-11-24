using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ExtraInformationAboutPayPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Extra information about pay";
        private static By WageInfoIframe => By.Id("WageAdditionalInformation_ifr");
        private static By IframeBody => By.CssSelector(".mce-content-body");


        public SubmitNoOfPositionsPage SubmitExtraInformationAboutPay()
        {
            javaScriptHelper.SwitchFrameAndEnterText(WageInfoIframe, IframeBody, rAADataHelper.OptionalMessage);
            Continue();

            return new SubmitNoOfPositionsPage(context);
        }
    }
}
