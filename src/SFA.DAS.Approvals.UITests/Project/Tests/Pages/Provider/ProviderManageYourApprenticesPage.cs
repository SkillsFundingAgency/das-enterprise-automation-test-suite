using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageYourApprenticesPage : BasePage
    {
        protected override string PageTitle => "Manage your apprentices";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        public ProviderManageYourApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By ApprenticeSearchField => By.Id("search-input");
        private By SearchButton => By.CssSelector(".submit-search");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeDetailsLink => By.LinkText("View");
        private By NextPageLink => By.PartialLinkText("Next");

        private ProviderManageYourApprenticesPage SearchForApprenntice(string apprenticeName)
        {
            _formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
            _formCompletionHelper.ClickElement(SearchButton);
            return this;
        }

        public ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            SearchForApprenntice(_dataHelper.ApprenticeFullName);
            while (true)
            {
                var apprenticeRows = _pageInteractionHelper.FindElements(ApprenticeInfoRow);
                var detailsLinks = _pageInteractionHelper.FindElements(ViewApprenticeDetailsLink);

                int i = 0;
                foreach (IWebElement apprenticeRow in apprenticeRows)
                {
                    if (apprenticeRow.Text.Contains(_dataHelper.ApprenticeFullName))
                    {
                        _formCompletionHelper.ClickElement(detailsLinks[i]);
                        return new ProviderApprenticeDetailsPage(_context);
                    }
                    i++;
                }
                if (_pageInteractionHelper.IsElementDisplayed(NextPageLink))
                {
                    _formCompletionHelper.ClickElement(NextPageLink);
                }
                else
                {
                    throw new Exception("Apprentice with - " + _dataHelper.ApprenticeFullName + " - name is not found");
                }
            }
        }
    }
}
