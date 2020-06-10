using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FundingAnApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "FUNDING AN APPRENTICESHIP";

        #region Page Object Elements
        private readonly By _subHeading1 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'The key facts')]");
        private readonly By _subHeading2 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprenticeship funding from the government')]");
        private readonly By _subHeading3 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprenticeship costs paid by you')]");
        private readonly By _subHeading4 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Paying for apprenticeships using a transfer of apprenticeship funds')]");
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprenticeships in Scotland, Northern Ireland and Wales')]");
        private readonly By _nonLevyText = By.XPath("//div[@class='page']/p");

        private readonly By _continueButton = By.XPath("//button[@type= 'submit']");

        private readonly ScenarioContext _context;

        #endregion

        public FundingAnApprenticeshipPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings()
        {

            pageInteractionHelper.VerifyText(_subHeading1, "THE KEY FACTS");
            pageInteractionHelper.VerifyText(_subHeading2, "APPRENTICESHIP FUNDING FROM THE GOVERNMENT");
            pageInteractionHelper.VerifyText(_subHeading3, "APPRENTICESHIP COSTS PAID BY YOU");
            pageInteractionHelper.VerifyText(_subHeading4, "PAYING FOR APPRENTICESHIPS USING A TRANSFER OF APPRENTICESHIP FUNDS");
            pageInteractionHelper.VerifyText(_subHeading5, "APPRENTICESHIPS IN SCOTLAND, NORTHERN IRELAND AND WALES");

        }

        public void CheckForNonLevyContent()
        {
            pageInteractionHelper.VerifyText(_nonLevyText, "As an employer with a pay bill of less than £3 million per year");
            
        }

    }
}
