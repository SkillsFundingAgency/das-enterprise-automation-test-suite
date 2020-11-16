using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageYourApprenticesPage : Navigate
    {
        protected override string PageTitle => "Manage your apprentices";
        protected override string Linktext => "Manage your apprentices";
        protected readonly ApprenticeDataHelper apprenticeDataHelper;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        public ProviderManageYourApprenticesPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();
            VerifyPage();
        }

        private By ApprenticeSearchField => By.Id("searchTerm");
        private By SearchButton => By.CssSelector(".das-search-form__button");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeFullName => By.PartialLinkText(apprenticeDataHelper.ApprenticeFullName);
        private By SelectFilterDropdown => By.Id("selectedStatus");
        private By ApplyFilter => By.XPath("//button[contains(text(),'Apply filters')]");
        private By ClearSearchAndFilters => By.PartialLinkText("Clear search");
        private By DownloadAllDataLink => By.PartialLinkText("Download all data");

        private By NextPageLink => By.PartialLinkText("Next");

        private ProviderManageYourApprenticesPage SearchForApprenntice(string apprenticeName)
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
                var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName);

                int i = 0;
                foreach (IWebElement apprenticeRow in apprenticeRows)
                {
                    if (apprenticeRow.Text.Contains(apprenticeDataHelper.ApprenticeFullName))
                    {
                        formCompletionHelper.ClickElement(detailsLinks);
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

        public ProviderManageYourApprenticesPage FilterPagination(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            formCompletionHelper.ClickElement(ApplyFilter);
            formCompletionHelper.ClickElement(NextPageLink);
            formCompletionHelper.ClickElement(ClearSearchAndFilters);
            return this;
        }

        public bool DownloadAllDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadAllDataLink);
    }
}
