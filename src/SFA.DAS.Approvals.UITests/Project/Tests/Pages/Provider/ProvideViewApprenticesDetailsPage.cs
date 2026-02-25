using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    // The count on the scrrens are about to introduce in next following sprints so commented to reuse this 
    // public class ProvideViewApprenticesDetailsPage(ScenarioContext context) : ReviewYourCohort(context, (x) => x < 2 ? "View apprentice details" : $"View {x} apprentices' details")
    public class ProvideViewApprenticesDetailsPage(ScenarioContext context) : ReviewYourCohort(context, (x) => "View apprentice details")
    {
        private static By ViewApprenticeLink => By.PartialLinkText("View");

        protected override string AccessibilityPageTitle => "Provider view apprentice details";

        internal ProviderViewApprenticeDetailsPage SelectViewApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> viewApprenticeLinks = pageInteractionHelper.FindElements(ViewApprenticeLink);
            formCompletionHelper.ClickElement(viewApprenticeLinks[apprenticeNumber]);
            return new ProviderViewApprenticeDetailsPage(context);
        }
    }
}
