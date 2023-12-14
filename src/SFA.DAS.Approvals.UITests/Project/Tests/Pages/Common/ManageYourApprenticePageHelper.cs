using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ManageYourApprenticePageHelper(ScenarioContext context) : ApprovalsBasePage(context, false)
    {
        private static By ApprenticeSearchField => By.Id("searchTerm");

        private static By SearchButton => By.CssSelector(".das-search-form__button");

        protected override string PageTitle => "";

        internal static By ViewApprenticeFullName(string linkText) => By.PartialLinkText(linkText);

        public bool DoesApprenticeExists(string name)
        {
            List<IWebElement> apprentices = [];

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                SearchForApprentice(name);

                if (!(pageInteractionHelper.IsElementDisplayedAfterPageLoad(ViewApprenticeFullName(name))))
                {
                    Assert.Fail("Apprentice '" + name + "' is not found");
                }

                apprentices = [.. pageInteractionHelper.FindElements(ViewApprenticeFullName(name))];
            },
            RetryTimeOut.GetTimeSpan([10, 20, 30, 60, 120, 180]));

            return apprentices.Count > 0;
        }

        public void SelectViewLiveApprenticeDetails(string name)
        {
            DoesApprenticeExists(name);

            var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName(name));

            formCompletionHelper.ClickElement(detailsLinks);
        }

        private FilteredManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            // Search bar will not be displayed if there are less than 10 apprentice in the table
            if (pageInteractionHelper.IsElementDisplayed(ApprenticeSearchField))
            {
                formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);

                formCompletionHelper.ClickElement(SearchButton);
            }

            return new FilteredManageYourApprenticesPage(context);
        }

    }
}

