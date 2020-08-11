using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class HireAnApprenticePage : EmployerBasePage
    {
        protected override string PageTitle => "HIRING AN APPRENTICE";

        #region Page Object Elements
        private readonly By _subHeading1 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Hiring outside your organisation')]");
        private readonly By _subHeading3 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Advertising your apprenticeship')]");
        private readonly By _subHeading4 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Choosing the right apprentice')]");
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Interview questions')]");
        #endregion
        public HireAnApprenticePage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(_subHeading1, "HIRING OUTSIDE YOUR ORGANISATION");
            pageInteractionHelper.VerifyText(_subHeading3, "ADVERTISING YOUR APPRENTICESHIP");
            pageInteractionHelper.VerifyText(_subHeading4, "CHOOSING THE RIGHT APPRENTICE");
            pageInteractionHelper.VerifyText(_subHeading5, "INTERVIEW QUESTIONS");
        }
    }
}

