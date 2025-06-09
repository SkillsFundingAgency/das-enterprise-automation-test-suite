using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class SupportGuidancePage(ScenarioContext context) : AppBasePage(context)
    {
        private static By SupportGuidanceHeader => By.CssSelector("h1.govuk-heading-xl");
        private static By YourRightsAsAnApprenticeLink => By.CssSelector("a.app-stack__link[href='/Support/Category/your-rights-as-an-apprentice']");
        private static By WhereToGetSupportLink => By.CssSelector("a.app-stack__link[href='/Support/Category/where-to-get-support']");
        private static By SupportForLearningDifficultyLink => By.CssSelector("a.app-stack__link[href='/Support/Category/where-to-get-support']");
        private static By SupportForCareExperiencedApprenticesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/support-for-care-experienced-apprentices']");
        private static By EndPointAssessmentsLink => By.CssSelector("a.app-stack__link[href='/Support/Category/end-point-assessments-epas']");
        private static By OffTheJobTrainingLink => By.CssSelector("a.app-stack__link[href='/Support/Category/off-the-job-otj-training']");
        private static By ConnectAndNetworkWithOtherApprenticesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/connect-and-network-with-other-apprentices']");
        private static By RolesAndResponsibilitiesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/roles-and-responsibilities']");
        private static By GetStudentDiscountsLink => By.CssSelector("a.app-stack__link[href='/Support/Category/get-student-discounts']");
        private static By AfterYourApprenticeshipLink => By.CssSelector("a.app-stack__link[href='/Support/Category/after-your-apprenticeship']");

        protected override string PageTitle => throw new System.NotImplementedException();
        public string SupportGuidancePageTitle()
        {
            return pageInteractionHelper.FindElement(SupportGuidanceHeader).Text;
        }
    }
}
