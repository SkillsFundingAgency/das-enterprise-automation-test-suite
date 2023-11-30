using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public abstract class SearchEventsBasePage : AanBasePage
    {
        private static string Published => "Published";
        private static string Cancelled => "Cancelled";
        private static string TrainingEvent => "Training event";
        private static string InPerson => "In person";
        private static string Online => "Online";
        private static string Hybrid => "Hybrid";
        private static string London => "London";
        private static string Apprentice => "Apprentice";
        private static string Employer => "Employer";
        private static string Regionalchair => "Regional chair";

        private static By FromDateField => By.CssSelector("#fromDate");
        private static By ToDateField => By.CssSelector("#toDate");
        private static By ApplyFilterButton => By.CssSelector("#filters-submit");

        private static By SelectedFilter(string x) => By.XPath($"//a[contains(@title,'{x}')]");

        protected static By FirstEventLink => By.CssSelector("li.das-search-results__list-item a");

        public SearchEventsBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public void FilterEventByTomorrow() => FilterEventBy(DateTime.Now.AddDays(1));

        public void FilterEventByOneMonth()
        {
            string formattedDate = DateTime.Now.AddDays(1).ToString(DateFormat);
            string formattedEndDate = DateTime.Now.AddDays(30).ToString(DateFormat);
            formCompletionHelper.EnterText(FromDateField, formattedDate);
            formCompletionHelper.EnterText(ToDateField, formattedEndDate);
            ApplyFilter();
        }

        protected void FilterEventBy(DateTime date)
        {
            string formattedDate = date.ToString(DateFormat);
            formCompletionHelper.EnterText(FromDateField, formattedDate);
            ApplyFilter();
        }

        protected void FilterEventByEventStatus_Published() => ApplyFilter(Published);

        protected void FilterEventByEventStatus_Cancelled() => ApplyFilter(Cancelled);

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

        protected void VerifyEventType_TrainingEvent_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(TrainingEvent));

        protected void VerifyEventFormat_Inperson_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(InPerson));
        protected void VerifyEventFormat_Online_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Online));
        protected void VerifyEventFormat_Hybrid_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Hybrid));

        protected void VerifyEventRegion_London_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(London));
        protected void VerifyRole_Apprentice_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Apprentice));
        protected void VerifyRole_Employer_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Employer));

        protected void VerifyRole_Regionalchair_Filter() => pageInteractionHelper.IsElementDisplayed(SelectedFilter(Regionalchair));

        private void ApplyFilter(string x) { SelectCheckBoxByText(x); ApplyFilter(); }

        private void ApplyFilter() => formCompletionHelper.ClickElement(ApplyFilterButton);
    }
}
