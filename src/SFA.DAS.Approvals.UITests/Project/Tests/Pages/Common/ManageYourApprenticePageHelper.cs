using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ManageYourApprenticePageHelper : ApprovalsBasePage
    {
        private static By ApprenticeSearchField => By.Id("searchTerm");

        private static By SearchButton => By.CssSelector(".das-search-form__button");

        protected override string PageTitle => "";

        internal static By ViewApprenticeFullName(string linkText) => By.PartialLinkText(linkText);

        public ManageYourApprenticePageHelper(ScenarioContext context) : base(context, false)
        {

        }

        public bool DoesApprenticeExists(string name)
        {
            return pageInteractionHelper.InvokeAction(() =>
            {
                SearchForApprentice(name);

                var x = pageInteractionHelper.FindElements(ViewApprenticeFullName(name)).ToList();

                if (x.Count != 0) return true;

                else throw new NoSuchElementException("Apprentice with - " + name + " - name is not found");
            });
        }

        public void SelectViewCurrentApprenticeDetails(string name)
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

