using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReviewYourCohort : CohortReferenceBasePage
    {
        #region Helpers and Context

        private string _pageTitle;

        #endregion Helpers and Context

        protected override string PageTitle => _pageTitle;
        protected virtual By TotalApprentices => By.CssSelector("table tbody tr");
        protected virtual By TotalCost => By.CssSelector(".dynamic-cost-display .bold-xlarge, .govuk-table__cell > strong");
        protected static By EditApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");
        protected static By FlexiJobAgencyTag => By.CssSelector("span.govuk-tag");
        protected static By PortableFlexiJobDeliveryModelTag => By.XPath("//span[@class='govuk-tag' and (text()='Portable flexi-job' or text()='Portable flexi job')]");

        protected ReviewYourCohort(ScenarioContext context, Func<int, string> func) : base(context, false) 
        {
            void SetPageTitle() => _pageTitle = func(TotalNoOfApprentices());

            SetPageTitle();

            VerifyPage(() => SetPageTitle());
        }

        protected List<IWebElement> TotalNoOfEditableApprentices() => pageInteractionHelper.FindElements(EditApprenticeLink);

        public int TotalNoOfApprentices() => TotalNoOfEditableApprentices().Count;

        public string ApprenticeTotalCost() => pageInteractionHelper.GetText(TotalCost);

        public void ValidateFlexiJobAgencyTag() => Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(FlexiJobAgencyTag));

        public void ValidatePortableFlexiJobTag() => Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PortableFlexiJobDeliveryModelTag));

        public void ValidateFlexiTagNotDisplayed() => Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(FlexiJobAgencyTag));
    }
}
