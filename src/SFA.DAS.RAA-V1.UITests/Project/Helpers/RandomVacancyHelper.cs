using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RandomVacancyHelper
    {
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ObjectContext _objectContext;

        public RandomVacancyHelper(PageInteractionHelper pageInteractionHelper, FormCompletionHelper formCompletionHelper, ObjectContext objectContext)
        {
            _pageInteractionHelper = pageInteractionHelper;
            _formCompletionHelper = formCompletionHelper;
            _objectContext = objectContext;
        }

        public IWebElement RandomElementAt(Func<IWebElement, bool> func, By VacancyTables, By VacancyTitle, By NextPage, By NoOfPagesCssSelector)
        {
            IWebElement randomElement = null;

            int randomNumber = 0;

            int noOfPages = NoOfPages(NoOfPagesCssSelector);

            for (int i = 1; i < noOfPages; i++)
            {
                List<IWebElement> filteredRows = _pageInteractionHelper.FindElements(VacancyTables).ToList().Where(x => func(x)).ToList();

                if (filteredRows.Count == 0)
                {
                    if (_pageInteractionHelper.IsElementDisplayed(NextPage))
                    {
                        _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(NextPage));
                        int currentPage = i + 1;
                        if (currentPage < noOfPages)
                        {
                            _pageInteractionHelper.WaitForElementToChange(NextPage, AttributeHelper.InnerText, $"{currentPage + 1} of {noOfPages}");
                        }
                    }
                    continue;
                }

                randomNumber = new Random().Next(1, filteredRows.Count);

                randomElement = filteredRows[randomNumber - 1];

                var vacTitle = _pageInteractionHelper.GetText(randomElement.FindElement(VacancyTitle));

                _objectContext.SetVacancyTitle(vacTitle);

                break;
            }

            return randomElement;
        }

        private int NoOfPages(By NoOfPagesCssSelector)
        {
            int noOfPages = 1;

            if (_pageInteractionHelper.IsElementDisplayed(NoOfPagesCssSelector))
            {
                noOfPages = int.Parse(_pageInteractionHelper.GetText(NoOfPagesCssSelector).Split("of")[1].Trim());
            }

            return noOfPages;
        }
    }
}
