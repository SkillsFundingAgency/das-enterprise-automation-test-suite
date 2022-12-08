using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => apprenticeDataHelper.ApprenticeFullName;
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeDetailsLink => By.LinkText("Edit apprentice");
        private By ViewIlrMismatchDetailsLink => By.LinkText("View details");
        private By ChangeEmployerLink => By.Id("change-employer-link");
        private By ChangeRequestHeading => By.XPath("//h2[contains(text(),'Changes to this apprenticeship')]");
        private By ChangeRequestMessage => By.CssSelector("p.govuk-body");
        private By Name => By.Id("apprentice-name");
        private By DateOfBirth => By.Id("apprentice-dob");
        private By Reference => By.Id("apprentice-reference");
        private By ChangeOfPartyBanner => By.Id("change-of-party-status-text");
        private By ViewChanges => By.Id("change-employer-link");        
        private By ViewChangesLink => By.LinkText("View changes");
        private By ViewDetailsLink => By.LinkText("View details");
        private By TriageLinkRestartLink => By.LinkText("View course mismatch");
        private By TriageLinkUpdateLink => By.LinkText("View price mismatch");
        private By DeliveryModel => By.Id("apprentice-deliverymodel");

        public ProviderApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        public ProviderReviewChangesPage ClickReviewChanges()
        {
            formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ProviderReviewChangesPage(context);
        }

        public ProviderEditApprenticeCoursePage EditApprentice()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderEditApprenticeCoursePage(context);
        }

        public ProviderEditApprenticeDetailsPage ClickEditApprenticeLink()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderEditApprenticeDetailsPage(context);
        }


        public ProviderAccessDeniedPage ClickEditApprenticeDetailsLinkGoesToAccessDenied()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewIlrMismatchDetails()
        {
            formCompletionHelper.ClickElement(ViewIlrMismatchDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(context);
        }

        public ProviderInformPage ClickChangeEmployerLink()
        {
            formCompletionHelper.Click(ChangeEmployerLink);
            return new ProviderInformPage(context);
        }

        public ProviderAccessDeniedPage ClickChangeEmployerLinkGoesToAccessDenied()
        {
            formCompletionHelper.Click(ChangeEmployerLink);
            return new ProviderAccessDeniedPage(context);
        }

        public void ConfirmChangeRequestPendingMessage()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeRequestHeading));
            string confirmationMessgage = pageInteractionHelper.GetText(ChangeRequestMessage);
            pageInteractionHelper.VerifyText(confirmationMessgage, "Change request pending:");
        }

        public void ConfirmNameDOBAndReferenceChanged(string expectedName, DateTime expectedDateOfBirth, string expectedReference)
        {
            var actualName = pageInteractionHelper.GetText(Name);
            var actualDateOfBirth = DateTime.Parse(pageInteractionHelper.GetText(DateOfBirth));
            var actualReference = pageInteractionHelper.GetText(Reference);

            pageInteractionHelper.VerifyText(actualName, expectedName);
            pageInteractionHelper.VerifyText(actualDateOfBirth.ToString(), expectedDateOfBirth.ToString());
            pageInteractionHelper.VerifyText(actualReference, expectedReference.ToString());

        }
        
        public ProviderViewChangesPage ClickViewChangesLink()
        {
            formCompletionHelper.Click(ViewChanges);
            return new ProviderViewChangesPage(context);
        }        

        public ProviderViewChangesPage ClickViewChanges()
        {
            formCompletionHelper.ClickElement(ViewChangesLink);
            return new ProviderViewChangesPage(context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewDetails()
        {
            formCompletionHelper.ClickElement(ViewDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(context);
        }      

        public bool IsCoELinkDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeEmployerLink);

        public string GetCoPBanner() => pageInteractionHelper.GetText(ChangeOfPartyBanner);

        public bool IsPricemismatchLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(TriageLinkUpdateLink);

        public bool IsCoursemismatchLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(TriageLinkRestartLink);

        private void ClickEditApprenticeDetailsLink() => formCompletionHelper.ClickElement(EditApprenticeDetailsLink);

        public ProviderApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(expected), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModel);
    }
}
