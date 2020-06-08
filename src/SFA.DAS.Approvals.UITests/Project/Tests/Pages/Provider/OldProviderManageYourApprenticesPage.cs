using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class OldProviderManageYourApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage your apprentices";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        public OldProviderManageYourApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        private By ApprenticeSearchField => By.Id("search-input");
        private By SearchButton => By.CssSelector(".submit-search");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeDetailsLink => By.LinkText("View");
        private By NextPageLink => By.PartialLinkText("Next");

        private OldProviderManageYourApprenticesPage SearchForApprenntice(string apprenticeName)
        {
            formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
            formCompletionHelper.ClickElement(SearchButton);
            return this;
        }

        public ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            SearchForApprenntice(apprenticeDataHelper.ApprenticeFullName);
            while (true)
            {
                var apprenticeRows = pageInteractionHelper.FindElements(ApprenticeInfoRow);
                var detailsLinks = pageInteractionHelper.FindElements(ViewApprenticeDetailsLink);

                int i = 0;
                foreach (IWebElement apprenticeRow in apprenticeRows)
                {
                    if (apprenticeRow.Text.Contains(apprenticeDataHelper.ApprenticeFullName))
                    {
                        formCompletionHelper.ClickElement(detailsLinks[i]);
                        return new ProviderApprenticeDetailsPage(_context);
                    }
                    i++;
                }
                if (pageInteractionHelper.IsElementDisplayed(NextPageLink))
                {
                    formCompletionHelper.ClickElement(NextPageLink);
                }
                else
                {
                    throw new Exception("Apprentice with - " + apprenticeDataHelper.ApprenticeFullName + " - name is not found");
                }
            }
        }
    }
}
