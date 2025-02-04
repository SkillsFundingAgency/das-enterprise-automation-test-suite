using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.Pages
{
    public class AodpLandingPage : AodpBasePage
    {

        protected override string PageTitle => "Add an organisation";

        public AodpLandingPage(ScenarioContext context) : base(context)
        {
            // // this is temp work aound as the redirection is not working correctly.
            // VerifyPage(() =>
            // {
            //     var uri = new Uri(new Uri(UrlConfig.Admin_BaseUrl), $"register/add-organisation");
            //     tabHelper.GoToUrl(uri.AbsoluteUri);
            //     return pageInteractionHelper.FindElements(PageHeader);
            // }, PageTitle);
             tabHelper.GoToUrl(UrlConfig.Aodp_BaseUrl);
        }


        
        public void verifyLandingPage()
        {
           
            // Add landing page validations
        }


    }
}