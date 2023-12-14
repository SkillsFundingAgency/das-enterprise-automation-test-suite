using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RandomVacancyHelper(PageInteractionHelper pageInteractionHelper, FormCompletionHelper formCompletionHelper, ObjectContext objectContext)
    {
        public IWebElement RandomElementAt(Func<IWebElement, bool> func, By VacancyTables, By VacancyTitle, By NextPage, By NoOfPagesCssSelector)
        {
            IWebElement randomElement = null;

            int randomNumber = 0;

            int noOfPages = NoOfPages(NoOfPagesCssSelector);

            for (int i = 1; i <= noOfPages; i++)
            {
                List<IWebElement> filteredRows = pageInteractionHelper.FindElements(VacancyTables).ToList().Where(x => func(x)).ToList();

                if (filteredRows.Count == 0)
                {
                    if (pageInteractionHelper.IsElementDisplayed(NextPage))
                    {
                        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(NextPage));
                        int currentPage = i + 1;
                        if (currentPage < noOfPages)
                        {
                            pageInteractionHelper.WaitForElementToChange(NextPage, AttributeHelper.InnerText, $"{currentPage + 1} of {noOfPages}");
                        }
                    }
                    continue;
                }

                randomNumber = new Random().Next(1, filteredRows.Count);

                randomElement = filteredRows[randomNumber - 1];

                var vacTitle = PageInteractionHelper.GetText(randomElement.FindElement(VacancyTitle));

                objectContext.SetVacancyTitle(vacTitle);

                break;
            }

            return randomElement;
        }

        private int NoOfPages(By NoOfPagesCssSelector)
        {
            int noOfPages = 1;

            if (pageInteractionHelper.IsElementDisplayed(NoOfPagesCssSelector))
                noOfPages = int.Parse(pageInteractionHelper.GetText(NoOfPagesCssSelector).Split("of")[1].Trim());

            return noOfPages;
        }
    }
}
