using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : InterimYourOrganisationsAndAgreementsPage(context, navigate)
    {

        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();

        #region Locators
        private static By TransferStatus => By.CssSelector("p.govuk-body");
        private static By AddNewOrganisationButton => By.CssSelector(".govuk-button");
        private static By TableCells => By.XPath("//td");
        private static By ViewAgreementLink() => By.PartialLinkText("View all agreements");
        private static By ViewAgreementLink(string accountLegalEntityPublicHashedId) => By.CssSelector($"[href*='{accountLegalEntityPublicHashedId}/agreements']");
        private static By OrgRemovedMessageInHeader => By.XPath("//h3");
        private static By RemoveLinkBesideNewlyAddedOrg => By.LinkText($"Remove organisation");

        #endregion

        public bool VerifyTransfersStatus(string expected) => VerifyElement(() => pageInteractionHelper.FindElements(TransferStatus), $"Transfers status:  {expected}");

        public SearchForYourOrganisationPage ClickAddNewOrganisationButton()
        {
            formCompletionHelper.ClickButtonByText(AddNewOrganisationButton, "Add an organisation");
            return new SearchForYourOrganisationPage(context);
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

            void action() => formCompletionHelper.ClickElement(() =>
            {
                var elements = pageInteractionHelper.FindElements(ViewAgreementLink(accountLegalEntityPublicHashedId));

                return elements.FirstOrDefault(x => x.Text == "View all agreements");
            });

            return ClickViewAgreementLink(action);
        }

        private YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink(Action action)
        {
            action.Invoke();

            return new YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(context, action);
        }

        public AreYouSureYouWantToRemovePage ClickOnRemoveAnOrgFromYourAccountLink()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AreYouSureYouWantToRemovePage(context);
        }

        public AccessDeniedPage ClickToRemoveAnOrg()
        {
            tableRowHelper.SelectRowFromTable("Remove organisation", $"{objectContext.GetOrganisationName()}");
            return new AccessDeniedPage(context);
        }

        public bool IsRemoveLinkBesideNewlyAddedOrg() => pageInteractionHelper.IsElementDisplayed(RemoveLinkBesideNewlyAddedOrg);

        public bool VerifyOrgRemovedMessageInHeader() => pageInteractionHelper.VerifyText(OrgRemovedMessageInHeader, $"You have removed {objectContext.GetOrganisationName()}");
    }
}