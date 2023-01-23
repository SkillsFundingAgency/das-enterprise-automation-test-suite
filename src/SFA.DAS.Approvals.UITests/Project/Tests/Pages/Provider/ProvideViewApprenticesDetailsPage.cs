using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProvideViewApprenticesDetailsPage : ReviewYourCohort
    {
        private static By ViewApprenticeLink => By.PartialLinkText("View");


        public ProvideViewApprenticesDetailsPage(ScenarioContext context) : base(context, (x) => x == 1 ? "View apprentice details" : $"View {x} apprentices' details") { }

        internal ProviderViewApprenticeDetailsPage SelectViewApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> viewApprenticeLinks = pageInteractionHelper.FindElements(ViewApprenticeLink);
            formCompletionHelper.ClickElement(viewApprenticeLinks[apprenticeNumber]);
            return new ProviderViewApprenticeDetailsPage(context);
        }
    }
}
