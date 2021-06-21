using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ApplicationOutcomePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application ";

        protected By InternalComments => By.CssSelector(".govuk-body.das-multiline-text, p:nth-child(4)");

        public ApplicationOutcomePage(ScenarioContext context) : base(context) => VerifyPage();
        public void VerifyExternalComments(string internalComments) => pageInteractionHelper.VerifyText(InternalComments, internalComments);

        public ApplicationOutcomePage VerifyApplicationOutcomePage(string expectedPage, string externalComments)
        {   
            pageInteractionHelper.VerifyText(PageHeader, expectedPage);
            
            if (!(string.IsNullOrEmpty(externalComments))) { VerifyExternalComments(externalComments); }
            
            return this;
        }
    }
}
