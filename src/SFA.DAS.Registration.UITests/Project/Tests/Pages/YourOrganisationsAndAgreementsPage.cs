using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage : InterimYourOrganisationsAndAgreementsPage
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;

        #region Locators
        private By TransferStatus => By.XPath("//p[3]");
        private By AddNewOrganisationButton => By.CssSelector(".govuk-button");
        private By TableCells => By.XPath("//td");
        private By ViewAgreementLink() => By.LinkText("View all agreements");
        private By ViewAgreementLink(string accountLegalEntityPublicHashedId) => By.CssSelector($"[href*='{accountLegalEntityPublicHashedId}']");
        private By OrgRemovedMessageInHeader => By.XPath("//h3");
        private By RemoveLinkBesideNewlyAddedOrg => By.LinkText($"Remove organisation");
        #endregion

        public YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        }

        public string GetTransfersStatus() => pageInteractionHelper.GetText(TransferStatus);

        public SearchForYourOrganisationPage ClickAddNewOrganisationButton()
        {
            formCompletionHelper.ClickButtonByText(AddNewOrganisationButton, "Add an organisation");
            return new SearchForYourOrganisationPage(_context);
        }

        public YourOrganisationsAndAgreementsPage VerifyNewlyAddedOrgIsPresent()
        {
            Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(objectContext.GetOrganisationName()),
                $"'{objectContext.GetOrganisationName()} is NOT listed under 'YourOrganisationsAndAgreementsPage'");
            return this;
        }

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink() => 
            ClickViewAgreementLink(() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewAgreementLink())));

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink(string orgName)
        {
            var accountLegalEntityPublicHashedId = _registrationSqlDataHelper.GetAccountLegalEntityPublicHashedId(objectContext.GetDBAccountId(), orgName);

            Action action = () => formCompletionHelper.ClickElement(() =>
            {
                var elements = pageInteractionHelper.FindElements(ViewAgreementLink(accountLegalEntityPublicHashedId));

                return elements.FirstOrDefault(x => x.Text == "View all agreements");
            });

            return ClickViewAgreementLink(action);
        }

        private YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink(Action action)
        {
            action.Invoke();

            return new YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(_context, action);
        }

        public AreYouSureYouWantToRemovePage ClickOnRemoveAnOrgFromYourAccountLink()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AreYouSureYouWantToRemovePage(_context);
        }

        public AccessDeniedPage ClickToRemoveAnOrg()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AccessDeniedPage(_context);
        }

        public bool IsRemoveLinkBesideNewlyAddedOrg() => pageInteractionHelper.IsElementDisplayed(RemoveLinkBesideNewlyAddedOrg);

        public bool VerifyOrgRemovedMessageInHeader() => pageInteractionHelper.VerifyText(OrgRemovedMessageInHeader, $"You have removed {objectContext.GetOrganisationName()}");
    }
}