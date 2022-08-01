using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProvideViewApprenticesDetailsPage : ReviewYourCohort
    {
        protected override string PageTitle => _pageTitle;
        private By ViewApprenticeLink => By.PartialLinkText("View");

        #region Helpers and Context
        private readonly string _pageTitle;
        #endregion

        public ProvideViewApprenticesDetailsPage(ScenarioContext context) : base(context, false)
        {           
            var noOfApprentice = TotalNoOfViewOnlyApprentices();
            _pageTitle = noOfApprentice < 2 ? "View apprentice details" : $"View {noOfApprentice} apprentices' details";
            VerifyPage();
        }

        internal ProviderViewApprenticeDetailsPage SelectViewApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> viewApprenticeLinks = pageInteractionHelper.FindElements(ViewApprenticeLink);
            formCompletionHelper.ClickElement(viewApprenticeLinks[apprenticeNumber]);
            return new ProviderViewApprenticeDetailsPage(context);
        }
    }
}
