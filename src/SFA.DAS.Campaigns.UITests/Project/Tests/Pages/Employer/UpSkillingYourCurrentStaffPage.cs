using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class UpSkillingYourCurrentStaffPage : EmployerBasePage
    {
        protected override string PageTitle => "UPSKILLING YOUR CURRENT STAFF";

        #region Page Object Elements
        private readonly By _subHeading1 = By.XPath("//h2[contains (@class, 'heading-m no-top-margin' ) and contains(text(), 'Boost staff performance and retention')]");
        private readonly By _subHeading2 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Develop new skills at any level')]");
        private readonly By _subHeading3 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'You do not have to give them a different job')]");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UpSkillingYourCurrentStaffPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(_subHeading1, "BOOST STAFF PERFORMANCE AND RETENTION");
            pageInteractionHelper.VerifyText(_subHeading2, "DEVELOP NEW SKILLS AT ANY LEVEL");
            pageInteractionHelper.VerifyText(_subHeading3, "YOU DO NOT HAVE TO GIVE THEM A DIFFERENT JOB");
        }
    }
}