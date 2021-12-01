using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePageNegativeMatch : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => $"Check your details";
        private By InsetText => By.CssSelector(".govuk-inset-text");
        private By FirstName => By.XPath("(//td[@class='govuk-table__cell'])[1]");
        private By LastName => By.XPath("(//td[@class='govuk-table__cell'])[2]");
        private By DOB => By.XPath("(//td[@class='govuk-table__cell'])[3]");

        public ApprenticeHomePageNegativeMatch(ScenarioContext context) : base(context)
        {
            _context = context;

            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}"),
                () => { AssertTopNavigationLinksNotToBePresent(); return true; },
                () => { AssertNotificationBanner(); return true; },
                () => { VerifyPageContent(); return true; }
            });
        }

        public ChangeYourPersonalDetailsPage GoToChangeYourPersonalDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("update your details");
            return new ChangeYourPersonalDetailsPage(_context);
        }

        private void AssertNotificationBanner()
        {
            VerifyNotificationBannerHeader("There seems to be a problem, we cannot find your apprenticeship.");
            VerifyNotificationBannerContent("Check your name and date of birth details. If they are incorrect, please update your details.");
        }

        private void VerifyPageContent()
        {
            pageInteractionHelper.VerifyText(FirstName, objectContext.GetFirstName());
            pageInteractionHelper.VerifyText(LastName, objectContext.GetLastName());
            pageInteractionHelper.VerifyText(DOB, objectContext.GetDateOfBirth().ToString("d MMM yyyy"));
            pageInteractionHelper.VerifyText(InsetText, "Contact your employer or training provider if your details are correct and we cannot find your apprenticeship.");
        }
    }
}
