using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public class AP_ApplicationOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Application overview";
        private string _organisationDetailsSectionCompletedText => "13 of 13 questions completed";
        private string _declarationsSectionCompletedText => "20 of 20 questions completed";
        private string _fHASectionCompletedText => "1 of 1 questions completed";
        private readonly ScenarioContext _context;

        #region Locators
        private By GoToOrganisationDetailsLink => By.LinkText("Go to organisation details");
        private By GoToDeclarationsLink => By.LinkText("Go to declarations");
        private By GoToFinancialHealthAssessmentLink => By.LinkText("Go to financial health assessment");
        private By OrganisationDetailsSectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[1]");
        private By DeclarationsSectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[2]");
        private By FHASectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[3]");
        #endregion

        public AP_ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OrganisationDetailsBasePage ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
        {
            formCompletionHelper.Click(GoToOrganisationDetailsLink);
            return new AP_OrganisationDetailsBasePage(_context);
        }

        public AP_DeclarationsBasePage ClickGoToDeclarationsLinkInApplicationOverviewPage()
        {
            formCompletionHelper.Click(GoToDeclarationsLink);
            return new AP_DeclarationsBasePage(_context);
        }

        public AP_FHABasePage ClickGoToFinancialHealthAssessmentLinkInApplicationOverviewPage()
        {
            formCompletionHelper.Click(GoToFinancialHealthAssessmentLink);
            return new AP_FHABasePage(_context);
        }

        public AP_ApplicationSubmittedPage ClickSubmitInApplicationOverviewPage()
        {
            Continue();
            return new AP_ApplicationSubmittedPage(_context);
        }

        public AP_ApplicationOverviewPage VerifyOrganisationDetailsSectionCompletedText()
        {
            pageInteractionHelper.VerifyText(OrganisationDetailsSectionCompletedTextLabel, _organisationDetailsSectionCompletedText);
            return this;
        }

        public AP_ApplicationOverviewPage VerifyDeclarationsSectionCompletedText()
        {
            pageInteractionHelper.VerifyText(DeclarationsSectionCompletedTextLabel, _declarationsSectionCompletedText);
            return this;
        }

        public AP_ApplicationOverviewPage VerifyFHASectionCompletedText()
        {
            pageInteractionHelper.VerifyText(FHASectionCompletedTextLabel, _fHASectionCompletedText);
            return this;
        }
    }
}
