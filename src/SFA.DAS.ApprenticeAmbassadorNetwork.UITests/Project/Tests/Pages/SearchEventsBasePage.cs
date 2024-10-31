using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using NUnit.Framework.Internal.Execution;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public abstract class SearchEventsBasePage(ScenarioContext context) : AanBasePage(context)
    {
        private static string Published => "Published";
        private static string New => "New";
        private static string Cancelled => "Cancelled";
        private static string Active => "Active";
        private static string TrainingEvent => "Training event";
        private static string InPerson => "In person";
        private static string Online => "Online";
        private static string Hybrid => "Hybrid";
        private static string London => "London";
        private static string Apprentice => "Apprentice";
        private static string Employer => "Employer";
        private static string Regionalchair => "Regional chair";

        private static By NextPageLink => By.LinkText("Next »");
        private static By EventTitle => By.CssSelector(".das-search-results__heading");
        private static By FromDateField => By.CssSelector("#fromDate");
        private static By ToDateField => By.CssSelector("#toDate");
        private static By ApplyFilterButton => By.CssSelector("#filters-submit");
        private static By SearchResultsHeading = By.ClassName("das-search-results__heading");
        private static By BodyText = By.ClassName("govuk-body");


        private static By SelectedFilter(string x) => By.XPath($"//a[contains(@title,'{x}')]");

        protected static By ListOfEvents => By.CssSelector("li.das-search-results__list-item");
        protected static By Keyword => By.CssSelector("#keyword");
        protected static By Location => By.CssSelector("#location");
        protected static By Radius => By.CssSelector("#Radius");
        protected static By OrderBy => By.CssSelector("#OrderBy");

        protected static By FirstEventLink => By.CssSelector("li.das-search-results__list-item a");

        public void FilterEventFromTomorrow() => FilterEventByDate(null);

        public void FilterEventByOneMonth() => FilterEventByDate(DateTime.Now.AddDays(30));

        public void SelectOrderByClosest()
        {
            SelectOrderBy("Closest");
        }

        public void FilterEventsByLocation(string location, int radius)
        {
            EnterLocation(location);
            EnterRadius(radius);
            ApplyFilter();
        }

        public void EnterKeywordFilter(string keyword)
        {
            EnterKeyword(keyword);
        }

        protected void FilterEventBy(DateTime startDate, DateTime endDate, string type, string region)
        {
            EnterDate(startDate, FromDateField);

            EnterDate(endDate, ToDateField);

            SelectCheckBoxByText(type);

            SelectCheckBoxByText(region);

            ApplyFilter();
        }

        protected void FilterEventByEventStatus_Published() => ApplyFilter(Published);
        protected void FilterAmbassadorByStatus_New() => ApplyFilter(New);

        protected void FilterEventByEventStatus_Cancelled() => ApplyFilter(Cancelled);
        protected void FilterEventByAmbassadorStatus_Active() => ApplyFilter(Active);

        protected void FilterEventByEventType_TrainingEvent() => ApplyFilter(TrainingEvent);

        protected void FilterEventByEventFormat_InPerson() => ApplyFilter(InPerson);

        protected void FilterEventByEventFormat_Online() => ApplyFilter(Online);

        protected void FilterEventByEventFormat_Hybrid() => ApplyFilter(Hybrid);

        protected void FilterEventByEventRegion_London() => ApplyFilter(London);

        protected void FilterByRole_Apprentice() => ApplyFilter(Apprentice);

        protected void FilterByRole_Employer() => ApplyFilter(Employer);

        protected void FilterByRole_Regionalchair() => ApplyFilter(Regionalchair);

        protected void ClearAllFilters() => formCompletionHelper.ClickLinkByText("Clear");

        protected void VerifyEventStatus_Published_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Published));
        protected void VerifyEventStatus_Cancelled_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Cancelled));
        protected void VerifyAMbassadorStatus_Published_New() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(New));
        protected void VerifyAMbassadorStatus_Published_Active() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Active));

        protected void VerifyEventType_TrainingEvent_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(TrainingEvent));

        protected void VerifyEventFormat_Inperson_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(InPerson));
        protected void VerifyEventFormat_Online_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Online));
        protected void VerifyEventFormat_Hybrid_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Hybrid));

        protected void VerifyEventRegion_London_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(London));
        protected void VerifyRole_Apprentice_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Apprentice));
        protected void VerifyRole_Employer_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Employer));

        protected void VerifyRole_Regionalchair_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Regionalchair));

        protected void SelectOrderBy(string selectedValue)
        {
            formCompletionHelper.SelectFromDropDownByText(OrderBy, selectedValue);
        }

        private void FilterEventByDate(DateTime? endDate)
        {
            EnterDate(DateTime.Now.AddDays(1), FromDateField);

            if (endDate != null) EnterDate(endDate, ToDateField);

            ApplyFilter();
        }

        private void EnterDate(DateTime? date, By by)
        {
            string formattedDate = date?.ToString(DateFormat);

            formCompletionHelper.EnterText(by, formattedDate);
        }

        private void EnterKeyword(string keyword)
        {
            formCompletionHelper.ClearText(Keyword);
            formCompletionHelper.EnterText(Keyword, keyword);
        }

        private void EnterLocation(string location)
        {
            formCompletionHelper.ClearText(Location);
            formCompletionHelper.EnterText(Location, location);
        }

        private void EnterRadius(int radius)
        {
            formCompletionHelper.SelectFromDropDownByText(Radius, radius == 0 ? $"Across England" : $"{radius} miles");
        }

        private void ApplyFilter(string x) { SelectCheckBoxByText(x); ApplyFilter(); }

        private void ApplyFilter() => formCompletionHelper.ClickElement(ApplyFilterButton);

        public List<NetworkEventSearchResult> GetSearchResults()
        {
            var index = 0;
            return pageInteractionHelper.FindElements(EventTitle)
                .Select(x => x.Text)
                .Select(x => new NetworkEventSearchResult
                {
                    EventTitle = x,
                    Index = index++
                })
                .ToList();
        }

        protected bool HasNextPageLink()
        {
            try
            {
                return pageInteractionHelper.FindElement(NextPageLink) != null;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        protected void ClickNextPageLink()
        {
            formCompletionHelper.Click(NextPageLink);
        }

        public void ClickNextPage()
        {
            ClickNextPageLink();
        }

        public bool HasNextPage()
        {
            return HasNextPageLink();
        }

        public void VerifyHeadingText(string expectedText)
        {
            pageInteractionHelper.VerifyText(SearchResultsHeading, expectedText);
        }

        public void VerifyBodyText(string expectedText)
        {
            pageInteractionHelper.VerifyText(BodyText, expectedText);
        }
    }
}
