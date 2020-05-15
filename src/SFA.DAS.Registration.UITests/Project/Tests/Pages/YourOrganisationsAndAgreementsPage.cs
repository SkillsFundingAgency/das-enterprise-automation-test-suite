using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimYourOrganisationsAndAgreementsPage
    {
        private readonly ScenarioContext _context;

        #region Locators
        private By TransferStatus => By.XPath("//p[3]");
        private By AddNewOrganisationButton => By.LinkText("Add an organisation");
        private By TableCells => By.XPath("//td");
        private By ViewAgreementLink => By.LinkText("View all agreements");
        private By OrgRemovedMessageInHeader => By.XPath("//h3");
        private By RemoveLinkBesideNewlyAddedOrg => By.LinkText($"Remove organisation");
        #endregion

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _context = context;

        public string GetTransfersStatus() => pageInteractionHelper.GetText(TransferStatus);

        public SearchForYourOrganisationPage ClickAddNewOrganisationButton()
        {
            formCompletionHelper.Click(AddNewOrganisationButton);
            return new SearchForYourOrganisationPage(_context);
        }

        public YourOrganisationsAndAgreementsPage VerifyNewlyAddedOrgIsPresent()
        {
            Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(objectContext.GetOrganisationName()),
                $"'{objectContext.GetOrganisationName()} is NOT listed under 'YourOrganisationsAndAgreementsPage'");
            return this;
        }

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink()
        {
            formCompletionHelper.Click(ViewAgreementLink);
            return new YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(_context);
        }

        public AreYouSureYouWantToRemovePage ClickOnRemoveAnOrgFromYourAccountLink()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AreYouSureYouWantToRemovePage(_context);
        }

        public bool IsRemoveLinkBesideNewlyAddedOrg() => pageInteractionHelper.IsElementDisplayed(RemoveLinkBesideNewlyAddedOrg);

        public bool VerifyOrgRemovedMessageInHeader() => pageInteractionHelper.VerifyText(OrgRemovedMessageInHeader, $"You have removed {objectContext.GetOrganisationName()}");
    }
}