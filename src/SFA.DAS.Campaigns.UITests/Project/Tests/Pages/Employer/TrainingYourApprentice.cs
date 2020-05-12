using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class TrainingYourApprenticePage : EmployerBasePage
    {
        protected override string PageTitle => "TRAINING YOUR APPRENTICE";

        #region Page Object Elements
        private readonly By _subHeading1 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprentices are trained to make an impact')]");
        private readonly By _subHeading2 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Training can be delivered flexibly to suit you')]");
        private readonly By _subHeading3 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'straight-forward commitment statement - not hours of paperwork')]");
        private readonly By _subHeading4 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Which activities count as off-the-job training?')]");
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Creating a gov.uk account')]");

        #endregion
        public TrainingYourApprenticePage(ScenarioContext context) : base(context) => VerifyHeadings();
        private void VerifyHeadings()
        {
            pageInteractionHelper.VerifyText(_subHeading1, "APPRENTICES ARE TRAINED TO MAKE AN IMPACT");
            pageInteractionHelper.VerifyText(_subHeading2, "TRAINING CAN BE DELIVERED FLEXIBLY TO SUIT YOU");
            pageInteractionHelper.VerifyText(_subHeading3, "THERE'S A STRAIGHT-FORWARD COMMITMENT STATEMENT - NOT HOURS OF PAPERWORK");
            pageInteractionHelper.VerifyText(_subHeading4, "WHICH ACTIVITIES COUNT AS OFF-THE-JOB TRAINING?");
            pageInteractionHelper.VerifyText(_subHeading5, "CREATING A GOV.UK ACCOUNT");

        }
    }
}