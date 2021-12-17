using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerSelectionPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Select an employer for your vacancy";

        private By SelectEmployerLinks => By.CssSelector("a");

        public RAA_EmployerSelectionPage(ScenarioContext context) : base(context) { }

        public RAA_EmployerInformationPage SelectAnEmployer()
        {
            var links = pageInteractionHelper.GetLinks(SelectEmployerLinks, "Select employer");

            formCompletionHelper.ClickElement(rAAV1DataHelper.Employers(links));

            return new RAA_EmployerInformationPage(context);
        }
    }
}
