using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EndPointAssessmentPage : EmployerBasePage
    {

        protected override string PageTitle => "END-POINT ASSESSMENTS";

        #region Page Object Elements
        private readonly By _subHeading1 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprentices are trained to make an impact')]");
        private readonly By _subHeading2 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'The end-point assessment')]");
        private readonly By _subHeading3 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Finding an end-point assessment organisation')]");
        private readonly By _subHeading4 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'The cost of an end-point assessment')]");
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Certification')]");
        #endregion

        public EndPointAssessmentPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(_subHeading1, "APPRENTICES ARE TRAINED TO MAKE AN IMPACT");
            pageInteractionHelper.VerifyText(_subHeading2, "THE END-POINT ASSESSMENT");
            pageInteractionHelper.VerifyText(_subHeading3, "FINDING AN END-POINT ASSESSMENT ORGANISATION");
            pageInteractionHelper.VerifyText(_subHeading4, "THE COST OF AN END-POINT ASSESSMENT");
            pageInteractionHelper.VerifyText(_subHeading5, "CERTIFICATION");

        }


    }
}